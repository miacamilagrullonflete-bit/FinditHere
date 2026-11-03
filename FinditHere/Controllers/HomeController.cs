using FinditHere.Models;
using FinditHere.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinditHere.Controllers
{
    public class HomeController : Controller
    {
        private readonly TmdbServices _tmdb;

        public HomeController (TmdbServices tmdb)
        {
            _tmdb = tmdb;
        }
        public async Task<IActionResult> Index()
        {
            var peliculas = await _tmdb.ObtenerPopularesAsync();
            return View(peliculas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

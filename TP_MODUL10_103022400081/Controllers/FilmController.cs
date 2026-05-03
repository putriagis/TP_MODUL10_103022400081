using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400081.Models;

namespace TP_MODUL10_103022400081.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>
        {
            new Film { Judul="Inception", Sutradara="Christopher Nolan", Tahun="2010", Genre="Sci-Fi", Rating="9.0"},
            new Film { Judul="Interstellar", Sutradara="Christopher Nolan", Tahun="2014", Genre="Sci-Fi", Rating="8.7"},
            new Film { Judul="Parasite", Sutradara="Bong Joon-ho", Tahun="2019", Genre="Thriller", Rating="8.6"}
        };

        [HttpGet]
        public ActionResult<List<Film>> GetAll()
        {
            return films;
        }

        [HttpGet("{index}")]
        public ActionResult<Film> GetByIndex(int index)
        {
            if (index < 0 || index >= films.Count)
                return NotFound();

            return films[index];
        }

        [HttpPost]
        public ActionResult AddFilm([FromBody] Film film)
        {
            films.Add(film);
            return Ok(films);
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteFilm(int index)
        {
            if (index < 0 || index >= films.Count)
                return NotFound();

            films.RemoveAt(index);
            return Ok(films);
        }
    }
}
    namespace MovieList.Controllers {
    
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        public JsonResult GetMovies()
        {
            var movieService = new MovieService();
            List<Movie> movies = movieService.GetMovies();
            return Json(movies);
        }
    }
    }

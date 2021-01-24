    namespace WebMVCAPP_L.Controllers
    {
        public class MoviesController : Controller
        {
            List<Movie> movieList = new List<Movie>();
    
            public IActionResult Index()
            {
                if(TempData["myData"]!=null){
                    movieList = (List<Movie>)TempData["myData"]
                 }
                return View(movieList);
            }
            [HttpPost]
            public IActionResult AddMovie()
            {
                int id = Convert.ToInt32(HttpContext.Request.Form["movieId"].ToString());
                string name = HttpContext.Request.Form["movieName"].ToString();
                string author = HttpContext.Request.Form["movieAuthor"].ToString();
    
                Movie movie = new Movie(id,name,author);
                movieList.Add(movie);
                 TempData["myData"] = movieList;
                return View("Index");
            }
        }
    }

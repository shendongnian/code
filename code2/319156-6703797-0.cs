    public class HomeController : Controller
    {
      private IMovieRepository _db = new MoviesDBEntities();
      public HomeController(IMovieRepository db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        return View(_db.MovieSet.ToList());
      }
    }

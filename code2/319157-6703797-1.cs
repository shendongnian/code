    public class HomeController : Controller
    {
      private IMovieRepository _db;
      public HomeController(IMovieRepository db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        return View(_db.MovieSet.ToList());
      }
    }

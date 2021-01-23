    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MainViewModel { Obj = new MyViewModel() });
        }
    }

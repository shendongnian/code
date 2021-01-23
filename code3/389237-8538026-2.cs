    public class Home : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MyModel model)
        {
            // do stuff
        }
        
    }

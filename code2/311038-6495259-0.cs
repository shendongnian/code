    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string pid, string foo)
        {
            // the pid and foo parameters are correctly assigned here
            return View();
        }
    }

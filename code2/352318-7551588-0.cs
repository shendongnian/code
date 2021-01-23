    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AjaxTest()
        {
            throw new Exception();
        }
    }

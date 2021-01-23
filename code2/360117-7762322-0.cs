    public class HomeController : Controller
    {
        public ITest test = new Test();
        public ActionResult Index()
        {
            return Content(test.TestMethod());
        }
    }

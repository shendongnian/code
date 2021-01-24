    public class TestController : Controller
    {
        public ActionResult Index()
        {
            var context = HttpContext;
    
            return View();
        }
    }

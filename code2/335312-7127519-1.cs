    public class TestController : Controller
    {       
        public ActionResult Index(string username )
        {
            var p = username;
            return View();
        }
    }

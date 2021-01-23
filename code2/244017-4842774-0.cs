        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                throw new Exception("error");
            }
        }

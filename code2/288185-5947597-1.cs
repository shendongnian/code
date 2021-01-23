        public class HomeController : Controller
        {
            [HandleError(View = "ErasErrorPage")]
            public ActionResult Index()
            {
                throw new Exception("oops");
            }
        }

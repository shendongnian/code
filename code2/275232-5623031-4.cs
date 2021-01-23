    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Does not require authorization
        }
        [Authorize]
        public ActionResult PrivateThing()
        {
            // requires authorization
        }
    }

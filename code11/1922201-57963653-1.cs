    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var shortName = User.Identity.Name;
            return View();
        }
    }

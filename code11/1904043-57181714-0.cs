    public class HomeController : Controller
    {
        // available for any user
        public IActionResult Index()
        {
            // false for anonymous, true for authenticated users
            // also without the Authorize attribute.
            var isAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }
        [Authorize]
        public IActionResult Login(string returnUrl)
        {
            return LocalRedirect(returnUrl);
        }
    }

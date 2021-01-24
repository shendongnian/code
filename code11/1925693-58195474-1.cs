    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            var userManager = HttpContext.GetUserManager<IdentityUser>();
            return View();
        }       
    }

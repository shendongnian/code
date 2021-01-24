    namespace Example.Controllers
    {
        [ValidateUserLoggedIn] // Action Filter class
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";
    
                return View();
            }
       }
    }

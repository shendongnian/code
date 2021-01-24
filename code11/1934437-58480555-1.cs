    using Microsoft.AspNetCore.Http; // Needed for the SetString and GetString extension methods
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            HttpContext.Session.SetString("Test", "Ben Rules!");
            return View();
        }
    
        public IActionResult About()
        {
            ViewBag.Message = HttpContext.Session.GetString("Test");
    
            return View();
        }
    }

    namespace MvcWebApplication.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /Home/
    
            public ActionResult Index()
            {
                return View(HttpContext.Application["LicenseFile"] as string);
            }
    
        }
    }

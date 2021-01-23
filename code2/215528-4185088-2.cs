    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            if (HttpContext.User != null)
            {
                RedirectToAction("Index", "Client");
            }
        }
    
    }

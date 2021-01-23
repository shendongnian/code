    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            if (HttpContext.User != null)
            {
                RedirectToAction(new {controller="Client", action="Index"});
            }
        }
    
    }

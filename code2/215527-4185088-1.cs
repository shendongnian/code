    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                RedirectToAction(new {controller="Client", action="Index"});
            }
        }
    
    }

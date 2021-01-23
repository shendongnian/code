    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                RedirectToAction("Index", "Client");
            }
        }
    
    }

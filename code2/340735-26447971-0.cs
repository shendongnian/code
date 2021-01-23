    public class RedirectController : Controller
    {
        public ActionResult Index()
        {
            var rd = this.RouteData.Values;
            string controller = rd["controller2"] as string;
            string action = rd["action2"] as string;
    
            rd.Remove("controller2");
            rd.Remove("action2");
            rd.Remove("controller");
            rd.Remove("action");
    
            return RedirectToActionPermanent(action, controller, rd);
        }
    }

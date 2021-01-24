    public class MyController : Controller
    {
        // Since you have globally registered [Authorize], this would be automatically Authorized
        public ActionResult MyAction()
        {
            // some code... 
        }
        
        [AllowAnonymous] // <-- do not authorize this action
        public ActionResult NoAuthorizeAction()
        {
            // some code... 
        }
    }

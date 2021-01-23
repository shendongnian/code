    [Authorize]
    public class SomeController : Controller 
    {
        // All logged in users
        public ActionResult Index() 
        {
            ...
        }
    
        [Authorize(Roles="Admin")] // Only Admins
        public ActionResult Details() 
        {
            ...
        }
    }

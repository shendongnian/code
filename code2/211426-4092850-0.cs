    [Authorize]
    public class AuthorizeController: Controller
    {
    }
    public class HomeController : AuthorizeController
    {
        ...
    }
    // don't inherit AccountController from AuthorizeController
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            ...
        }
    }

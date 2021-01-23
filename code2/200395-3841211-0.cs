    public class AccountController : Controller
    {
         public ActionResult Register()
         {
             return View("Register", Register.RegisterUser());
         }
    }

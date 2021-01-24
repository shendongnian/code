    using MyExample.Models
    namespace MyExample.Controllers
    {
        public class LoginController : Controller
        {
          public ActionResult Login()
          {
           return View(new LoginRequestModel());
          }
        }
    }

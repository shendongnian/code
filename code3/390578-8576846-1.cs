    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            // do UserModel stuff
            return View();
        }
    
        [HttpPost]
        public ActionResult AnotherAction(SomeOtherModel model)
        {
            // do SomeOtherModel stuff
            return View();
        }
    }

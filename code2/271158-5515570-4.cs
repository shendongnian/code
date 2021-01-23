    public class AdminController : Controller
    {
        private readonly IAuthenticationService _authService;
        public AdminController(IAuthenticationService authService)
        {
            _authService = authService;
        }
    
        public ActionResult Register(RegisterModel userInfo)
        {
            if (!_authService.EmailIsUnique(userInfo.Email))
            {
                ModelState.AddModelError("Email", Strings.EmailMustBeUnique);
                return View(userInfo);
            }
            return RedirectToAction("Success");
        }
    }

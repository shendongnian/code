    	[Authorize(AuthenticationSchemes = "user_by_cookie")]
    public class LoginController : Controller
    {
        
		[HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
		
		[HttpPost]
        [AllowAnonymous]
        public IActionResult Index()
        {
            ...
			//authenticate();
			...
			return View();
        }
		
	    [HttpGet]
        public IActionResult Logout()
        {
            ..
			// logout();  -> 
			..
            return RedirectToAction("Index");
        }
		
	}

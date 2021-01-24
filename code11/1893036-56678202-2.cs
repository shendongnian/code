        [Area("Identity")]        
        public class AccountController : BaseController
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
    
    
            public AccountController(
             UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager
             )
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }
    
    
            // GET: /Account/SignIn            
            [HttpGet]
            [AllowAnonymous]
            public async Task<IActionResult> SignIn(string returnUrl = null)
            {                
                return View();
            }
        }

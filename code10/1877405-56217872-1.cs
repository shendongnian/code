    public class LoginController : Controller
    {    
        [HttpGet]    
        public IActionResult SuperUser(string redirectUrl)
        {
            // return a page to enter credentials
            // Include redirectUrl as field
        }
        [HttpPost]
        public IActionResult SuperUser(LoginData loginData)
        {
            // Validate User & Password
            Response.Cookies.Append("SuperUserCookie", "SomeValue");
            return Redirect(loginData.RedirectUrl);
        }
    }

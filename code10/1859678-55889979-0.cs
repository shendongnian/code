        [Route("api/[controller]")]
        public class AuthController : Controller
        {
            [HttpGet]
            [Route("getlogin")]
            public string GetLogin()
            {
                if (User.Identity.IsAuthenticated)
                {
                    return $"{User.Identity.Name}";
                }
    
                return string.Empty;
            }
    
            [HttpGet]
            [Route("getrole")]
            public string GetRole()
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return "Admin";
                    }
    
                    return "User";
                }
    
                return string.Empty;
            }
        }

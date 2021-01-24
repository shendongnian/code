        public class HomeController : Controller
        {
            //Action to issue a challange to google login
            public IActionResult LogInMicrosoft(string provider)
            {
                //provider = Microsot or Google or LinkedIn or Twitter or Facebook
                provider = "Microsoft";
                var authenticationProperties = new AuthenticationProperties
                {
                    RedirectUri = Url.Action("externallogincallback")
                };
                return Challenge(authenticationProperties, provider);
            }
            [Route("/[action]")]
            public async Task<IActionResult> externallogincallback()
            {
                var request = HttpContext.Request;
                //Here we can retrieve the claims
                // read external identity from the temporary cookie
                //var authenticateResult = HttpContext.GetOwinContext().Authentication.AuthenticateAsync("ExternalCookie");
                var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                if (result.Succeeded != true)
                {
                    throw new Exception("External authentication error");
                }
                // retrieve claims of the external user
                var externalUser = result.Principal;
                if (externalUser == null)
                {
                    throw new Exception("External authentication error");
                }
                // retrieve claims of the external user
                var claims = externalUser.Claims.ToList();
                // try to determine the unique id of the external user - the most common claim type for that are the sub claim and the NameIdentifier
                // depending on the external provider, some other claim type might be used
                //var userIdClaim = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
                var userIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                {
                    throw new Exception("Unknown userid");
                }
                var externalUserId = userIdClaim.Value;
                var externalProvider = userIdClaim.Issuer;
                // use externalProvider and externalUserId to find your user, or provision a new user
                return RedirectToAction("Privacy", "Home");
            }
            public IActionResult Index()
            {
                return View();
            }
            public IActionResult Privacy()
            {
                return View();
            }
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

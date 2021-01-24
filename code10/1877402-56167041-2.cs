C#
//startup
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme)
                .AddCookie("SuperUserTwoStep",op=>op.LoginPath = "/account/superuser2steplogin");
            services.AddAuthorization(op =>
            {
                op.AddPolicy("SuperUser", b => b.AddAuthenticationSchemes("SuperUserTwoStep")
                    .RequireAuthenticatedUser()
                    .RequireClaim(ClaimTypes.Role, "SuperUser"));
            });
C#
// login 
        public static IDictionary<string, string> States { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        [Route("/account/superuser2steplogin")]
        public async Task<IActionResult> LoginTwoStepConfirm(string returnUrl, [FromServices]IAuthorizationService authorizationService,
            [FromServices]IAuthorizationPolicyProvider policyProvider)
        {
            
            var winresult = await HttpContext.AuthenticateAsync(IISDefaults.AuthenticationScheme);
            if (winresult.Succeeded)
            {
                if (States.TryGetValue(winresult.Principal.Identity.Name, out _))
                {
                    States.Remove(winresult.Principal.Identity.Name);
                    var principal = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(winresult.Principal.Claims,"twostepcookie"));
                    await HttpContext.SignInAsync("SuperUserTwoStep", principal);
                    return Redirect(returnUrl);
                }
                else
                {
                    States[winresult.Principal.Identity.Name] = "1";
                    return Challenge(IISDefaults.AuthenticationScheme);
                }
            }
            else
            {
                return Challenge(IISDefaults.AuthenticationScheme);
            }
        }
C#
        [Authorize("SuperUser")]
        public IActionResult YourSecurePage()
        {
            return Content("hello world");
        }
the most difficult thing is to track that this is the second time to login, I try to use cookie , but it doen't work, so I crate a `static IDitionary<string,string>` to track ，**maybe use distributed cache is better**

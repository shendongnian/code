        public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
        {
            private readonly SignInManager<IdentityUser> _signInManager;
            public CustomCookieAuthenticationEvents(SignInManager<IdentityUser> signInManager)
            {
                // Get the database from registered DI services.
                _signInManager = signInManager;
            }
            public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
            {
                var userPrincipal = context.Principal;
                var user = await _signInManager.ValidateSecurityStampAsync(userPrincipal);
                if (user == null)
                {
                    context.RejectPrincipal();
                    await context.HttpContext.SignOutAsync(
                        IdentityConstants.ApplicationScheme);
                }
            }
        }

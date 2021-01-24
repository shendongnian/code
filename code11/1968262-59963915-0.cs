    public class RequireReauthenticationAttribute : Attribute, IAsyncResourceFilter
    {
        private int _timeElapsedSinceLast;
        public RequireReauthenticationAttribute(int timeElapsedSinceLast)
        {
            _timeElapsedSinceLast = timeElapsedSinceLast;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var foundAuthTime = int.TryParse(context.HttpContext.User.FindFirst(AppClaimTypes.AuthTime)?.Value, out int authTime);
    
            if (foundAuthTime && DateTime.UtcNow.ToUnixTimestamp() - authTime < _timeElapsedSinceLast)
            {
                await next();
            }
            else
            {
                var state = new Dictionary<string, string> { { "reauthenticate", "true" } };
                await context.HttpContext.Authentication.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties(state)
                {
                    RedirectUri = context.HttpContext.Request.Path
                }, ChallengeBehavior.Unauthorized);
            }
        }
    }

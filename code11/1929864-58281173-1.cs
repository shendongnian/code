    public class AuthorizeMultiplePolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorization;
        public string[] _policies { get; private set; }
        public AuthorizeMultiplePolicyFilter(string[] policies,IAuthorizationService authorization)
        {
            _policies = policies;
            _authorization = authorization; 
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
                foreach (var policy in _policies)
                {
                    var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, policy);
                    if (!authorized.Succeeded)
                    {
                        context.Result = new ForbidResult();
                        return;
                    }
                }
          
        }
    }

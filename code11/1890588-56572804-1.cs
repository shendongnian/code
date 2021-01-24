    public class AuthorizeMultiplePolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorization;
        public string _role { get; private set; }
        public string _policy { get; private set; }
        public AuthorizeMultiplePolicyFilter(string role, string policy, IAuthorizationService authorization)
        {
            _role = role;
            _policy = policy;
            _authorization = authorization;
           
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var policyAuthorized = await _authorization.AuthorizeAsync(context.HttpContext.User, _policy);
            var roleAuthorized = context.HttpContext.User.IsInRole(_role);
            if(!policyAuthorized.Succeeded && !roleAuthorized)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }

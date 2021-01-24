    public class Service
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAuthorizationService authzService;
        public Service(IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authzService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.authzService = authzService;
        }
        public async Task ServiceFunction()
        {
            var httpContext = httpContextAccessor.HttpContext;
            var isAuthenticated = httpContext?.User?.Identity?.IsAuthenticated ?? false;
            if (isAuthenticated)
            {
                // The user is authenticated.
                var authzResult = await authzService.AuthorizeAsync(
                    httpContext.User,
                    "PolicyName");
                if (authzResult.Succeeded)
                {
                    // The user is authorised.
                }
            }
        }
    }

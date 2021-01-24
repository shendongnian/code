    public class Service
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public Service(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void ServiceFunction()
        {
            var httpContext = httpContextAccessor.HttpContext;
            var isAuthenticated = httpContext?.User?.Identity?.IsAuthenticated ?? false;
            if (isAuthenticated)
            {
                // The user is authenticated.
            }
        }
    }

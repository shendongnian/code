    public class ValidationRequirement : IAuthorizationRequirement
        {
            public string Issuer { get; }
            public string Scope { get; }
    
            public HasScopeRequirement(string scope, string issuer)
            {
                Scope = scope ?? throw new ArgumentNullException(nameof(scope));
                Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
            }
        }
    
    
        public class ValidationHandler : AuthorizationHandler<ValidationRequirement>
        {
            IHttpContextAccessor _httpContextAccessor;
    
            public HasScopeHandler(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }
    
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
            {
    
                var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
    
                //context.Succeed(requirement);
                
                return Task.CompletedTask;
            }
        }

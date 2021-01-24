    public class LogicalOrAuthorizationHandler : AuthorizationHandler<LogicalOrRequirement>
    {
        public LogicalOrAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, LogicalOrRequirement requirement)
        {
            var httpContext = this._httpContextAccessor.HttpContext;
            var policyEvaluator = httpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            foreach (var policy in requirement.Policies)
            {
                var authenticateResult = await policyEvaluator.AuthenticateAsync(policy, httpContext);
                if (authenticateResult.Succeeded)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }

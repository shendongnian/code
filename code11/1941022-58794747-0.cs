    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; }
        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        IHttpContextAccessor _httpContextAccessor = null;
        public MinimumAgeHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       MinimumAgeRequirement requirement)
        {
            var data = _httpContextAccessor.HttpContext.Request.RouteValues;
            //...
        }
    }

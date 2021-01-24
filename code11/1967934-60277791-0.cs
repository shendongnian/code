    public class RoleRequirementAttribute : TypeFilterAttribute
    {
        public RoleRequirementAttribute(params string[] claimValues) 
            : base(typeof(RoleRequirementFilter))
        {
            Arguments = new []{ claimValues.Select(cv => new Claim(ClaimTypes.Role, cv)) };
        }
    }
    public class RoleRequirementFilter : IAuthorizationFilter
    {
        readonly IEnumerable<Claim> _claims;
        public RoleRequirementFilter(IEnumerable<Claim> claims)
        {
            _claims = claims;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim =  context.HttpContext.User.Claims.Any(owned => _claims.Any(required => owned.Type == required.Type && owned.Value == required.Value));
            
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }

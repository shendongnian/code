    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserRoles _requiredRoles; // Enum of Roles
        public AuthorizationFilter(IAuthorizationService authorizationService, UserRoles requiredRoles)
        {
            _authorizationService = authorizationService;
            _requiredRoles = requiredRoles;
        }
        
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // do work, or HandleUnauthorizedRequest()
        }
        protected void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // do work
        }
    }
    public class RequireRolesAttribute : FilterAttribute
    {
        public readonly UserRoles RequiredRoles;
        public RequireRolesAttribute(UserRoles requiredRoles)
        {
            RequiredRoles = requiredRoles;
        }        
    }

    public class AuthorizeRolesAttribute : Attribute, IAuthorizationFilter 
    {
        private readonly Permission[] permissions;
        public AuthorizeRolesAttribute(params Permission[] permissions)
        {
            this.permissions = permissions;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string[] roles = Authentication.GetRoles(permissions).Split(",");
            bool allowed = context.HttpContext.User.Claims.Any(c => c.Type.Contains("role") && roles.Contains(c.Value));
            if (!allowed)
                context.Result = new ForbidResult();
        }
    }

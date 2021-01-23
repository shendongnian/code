    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly RoleSet authorizedRoles;
        public AuthorizeRolesAttribute(params Role[] roles)
        {
            authorizedRoles = new RoleSet(roles);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return authorizedRoles.Includes(httpContext.User);
        }
    }

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Permission[] permissions)
        {   
            Roles = GetRoles(permissions);
        }
    }

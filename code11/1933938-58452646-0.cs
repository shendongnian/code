    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles)
        {
            if (roles != null)
                Roles = string.Join(",", roles);
        }
    }

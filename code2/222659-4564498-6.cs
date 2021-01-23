    public class ApplicationUser : IPrincipal
    {
        private readonly RoleSet roles;
        public ApplicationUser(RoleSet roles)
        {
            this.roles = roles;
        }
        public bool IsInRole(string role)
        {
            return roles.Includes(role);
        }
        public IIdentity Identity
        {
            get { return new GenericIdentity("User"); }
        }
    }

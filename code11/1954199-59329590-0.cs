    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAuthorizeAttribute : Attribute
    {
        public IEnumerable<string> AllowedUserRoles { get; private set; }
    
        public CustomAuthorizeAttribute(params string[] allowedUserRoles)
        {
            this.AllowedUserRoles = allowedUserRoles.AsEnumerable();
        }
    }

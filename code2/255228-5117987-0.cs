    Attribute:
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public Role[] RoleList { get; set; }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            //Only role access is implemented here
            /*if ((this._usersSplit.Length > 0) && !this._usersSplit.Contains<string>(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }*/
            if ((RoleList.Length > 0) && !RoleList.Select(p=>p.ToString()).Any<string>(new Func<string, bool>(user.IsInRole)))
            {
                return false;
            }
            return true;
        }
    }
 

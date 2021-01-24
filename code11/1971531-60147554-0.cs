    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var user = actionContext.ControllerContext.RequestContext.Principal;
            if (!(user == null || user.Identity == null))
            {
                var roles = GetDeniedRoles();
                if (roles != null && roles.Count() > 0 && roles.Any(user.IsInRole))
                {
                    return false;
                }
            }
            return base.IsAuthorized(actionContext);
        }
        public virtual IEnumerable<string> GetDeniedRoles()
        {
            var config = System.Configuration.ConfigurationManager.AppSettings["DeniedRoles"];
            var roles = config?.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x));
            return roles;
        }
    }

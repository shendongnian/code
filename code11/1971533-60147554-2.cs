    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    public class DenyAccessAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new System.ArgumentNullException(nameof(actionContext));
            if (!IsAuthorized(actionContext))
                HandleUnauthorizedRequest(actionContext);
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var user = actionContext.ControllerContext.RequestContext.Principal;
            if (!(user == null || user.Identity == null))
            {
                var roles = GetDeniedRoles();
                if (roles != null && roles.Count() > 0 && roles.Any(user.IsInRole))
                    return false;
            }
            return base.IsAuthorized(actionContext);
        }
        public virtual IEnumerable<string> GetDeniedRoles()
        {
            var config = System.Configuration.ConfigurationManager
                .AppSettings["DeniedRoles"];
            var roles = config?.Split(',').Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x));
            return roles;
        }
    }

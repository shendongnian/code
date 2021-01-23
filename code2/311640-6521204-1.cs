    namespace System.Web.Mvc
    {
        public class AuthorizeAjaxAttribute : AuthorizeAttribute
        {
            private bool _failedAuthorisation;
    
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (!httpContext.User.Identity.IsAuthenticated)
                {
                    _failedAuthorisation = true;
                    return false;
                }
                else
                {
                    String[] RoleArray = Roles.Split(',');
                    foreach (var r in RoleArray)
                    {
                        if (httpContext.User.IsInRole(r))
                        {
                            _failedAuthorisation = false;
                            return true;
                        }
                    }
    
                    _failedAuthorisation = true;
                    return false;
                }
            }
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);
    
                if (_failedAuthorisation)
                {
                    filterContext.Result = new PartialViewResult { ViewName = "AjaxAccessError" };
                }
            }
        }
    }

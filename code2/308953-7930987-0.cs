    public class SiteMapAuthorizeAttribute : AuthorizeAttribute
    {
        public string Action { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
            var node = SiteMap.CurrentNode;
            // If the node is null, then it was not loaded into memory 
            // because this user was not authorized to view this node
            if (node == null)
                return false;
            // Check the node's accessibility regardless in case we got passed the above check
            return node.IsAccessibleToUser(HttpContext.Current);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // If user is not authenticated allow default handling
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }
            string customErrorPage = GetCustomError("403");
            if (customErrorPage == null)
            {
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }
            // Redirect to 403 (Access Denied) page
            filterContext.Result = new RedirectResult(customErrorPage);
        }
        private string GetCustomError(string statusCode)
        {
            CustomErrorsSection customErrorsSection = ConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;
            if (customErrorsSection != null)
            {
                CustomError customErrorPage = customErrorsSection.Errors[statusCode];
                if (customErrorPage != null)
                    return customErrorPage.Redirect;
            }
            return null;
        }
    }

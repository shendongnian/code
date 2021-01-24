    public class AdminAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // If you are authorized
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                // else redirect to your Area  specific login page
                filterContext.Result = new RedirectResult("~/Area/Admin/Account/Login");
            }
        }
    }

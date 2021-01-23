    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result == null)
            {
                
                if (filterContext.HttpContext.Session != null )
                {
                    //add checks for your configuration
                    //add session data
                    // if you have a url you can use RedirectResult
                    // in this example I use RedirectToRouteResult
                    RouteValueDictionary rd = new RouteValueDictionary();
                    rd.Add("controller", "Account");
                    rd.Add("action", "LogOn");
                    filterContext.Result = new RedirectToRouteResult("Default", rd);
                }
            }
        }
    }            
        

    public class LoadCustomAuthTicket : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated)
                return;
            HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return;
            
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var identity = new GenericIdentity(authTicket.Name, "Forms");
            var principal = new GenericPrincipal(identity, new string[] { });
            // Make sure the Principal's are in sync. see: https://www.hanselman.com/blog/SystemThreadingThreadCurrentPrincipalVsSystemWebHttpContextCurrentUserOrWhyFormsAuthenticationCanBeSubtle.aspx
            filterContext.Principal = filterContext.HttpContext.User = System.Threading.Thread.CurrentPrincipal = principal;
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //This method is responsible for validating the current principal and permitting the execution of the current action/request.
            //Here you should validate if the current principle is valid / permitted to invoke the current action. (However I would place this logic to an authorization filter)
            //filterContext.Result = new RedirectToRouteResult("CustomErrorPage",null);
        }
    }

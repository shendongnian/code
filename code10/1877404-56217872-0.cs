    public class SuperUserFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Cookies.TryGetValue("SuperUserCookie", out string cookieVal))
            {
                if (!IsValidCookie(cookieVal))
                    context.Result = LoginPage(context);
            }
            else
            {
                context.Result = LoginPage(context);
            }
        }
        private bool IsValidCookie(string cookieVal)
        {
            //validate cookie value somehow
            // crytpographic hash, store value in session, whatever
            return true;
        }
        private ActionResult LoginPage(AuthorizationFilterContext context)
        {
            return new RedirectToActionResult("SuperUser", "Login",
                new {redirectUrl = context.HttpContext.Request.GetEncodedUrl()});
        }
    }

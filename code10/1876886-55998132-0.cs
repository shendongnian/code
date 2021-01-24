    public class CustomAuth : Attribute, IAuthorizationFilter
    {
        public CustomAuth()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cookies = context.HttpContext.Request.Cookies;
            var ok = cookies["Auth0"] == "asdf";
            if (!ok)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
        }
    }

    public class BearerAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            // 1. Look for credentials in the request.
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            // 3. If there are credentials but the filter does not recognize the 
            //    authentication scheme, do nothing.
            if (authorization.Scheme != "Bearer")
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            //4.If there are credentials that the filter understands, try to validate them.          
            if (!String.IsNullOrEmpty(authorization.Parameter))
            {
                var apiKey = string.Empty;               
                if (!TokenService.IsValidToken(authorization.Parameter))
                {
                    context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }
                return;
            }
        }
    }

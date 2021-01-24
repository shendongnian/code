    public class CustomAuthorization : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            var ctx = actionContext;
            var token = ctx.Request.Headers.Authorization.Parameter;
            var handler = new CustomJWTTokenHandler();
            if (ctx.Response.StatusCode == HttpStatusCode.Unauthorized && handler.TokenHasExpired(token))
            {
                ctx.Response.Headers.Add("Token-Expired", "true");
            }
        }
    }

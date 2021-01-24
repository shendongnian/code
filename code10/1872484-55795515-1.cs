    public class AcceptHeaderAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool result = context.HttpContext.Request.Headers["Accept"].ToString() == "app/version.abc-ghi-api.v";
            if (!result)
            {
                var result = new Error.GenerateErrorMessage("Accept header validation failed", Log.Logger);
                context.Result = result;
            }
        }
    }

    public static class CustomAuthorizationMiddleware
    {
        public static async Task Authorize(HttpContext httpContext, Func next)
        {
            var endpointMetaData = httpContext.GetEndpoint().Metadata;
     
            bool hasCustomAuthorizeAttribute = endpointMetaData.Any(x => x is CustomAuthorizeAttribute);
     
            if (!hasCustomAuthorizeAttribute)
            {
                await next.Invoke();
                return;
            }
     
            CustomAuthorizeAttribute customAuthorizeAttribute = endpointMetaData
                    .FirstOrDefault(x => x is CustomAuthorizeAttribute) as CustomAuthorizeAttribute;
     
            // Check if user has allowed role or super administrator role
            bool isAuthorized = customAuthorizeAttribute.AllowedUserRoles
                .Any(allowedRole => httpContext.User.IsInRole(allowedRole) || httpContext.User.IsInRole("SuperAdministrator"));
     
            if (isAuthorized)
            {
                await next.Invoke();
                return;
            }
     
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await httpContext.Response.WriteAsync("unauthorized");
        }
    }

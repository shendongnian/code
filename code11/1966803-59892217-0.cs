    public async Task Invoke(HttpContext httpContext, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        // Check if endpoint has any authorize data, like [Authorize] attribute
        var endpoint = context.GetEndpoint();
        var authorizeData = endpoint?.Metadata.GetOrderedMetadata<IAuthorizeData>();
        if (authorizeData != null && authorizeData.Any())
        {
            // If you need to depend on particular scheme ("Bearer" in my example):
            var scheme = authorizeData[0].AuthenticationSchemes;
            if (scheme == JwtBearerDefaults.AuthenticationScheme)
            {
                // Code only for "Bearer" auth scheme
            }
            
            
            var headerKeys = httpContext.Request.Headers.Keys;
            // **issue comes here**
            // **it always discard the request which does not have any token.**
            if (headerKeys.Contains("Authorization"))
            {
                // validation code, which hits another server.                       
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsync("Unauthorized Access");
                return;
            }
        }
        await _next.Invoke(httpContext);
    }

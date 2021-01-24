            private readonly RequestDelegate _next;
    
            public MyMiddleware(RequestDelegate next)
            {
    
                _next = next;
            }
    
            public async Task InvokeAsync(HttpContext httpContext, IConfiguration configuration)
            {
                if (httpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    
                    var authorizationToken = httpContext.Request.Headers["Authorization"].ToString();
    
                    if (!authorizationToken.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
                    {
                        await UnauthorizedResponseAsync(httpContext);
                    }
                    else
                    {
                        var token  =authorizationToken.Substring("Bearer".Length).Trim())
    
                       if (httpContext.Request.Path == "Some of your path")
                       {
                       // DO your stuff
                       await _next.Invoke(httpContext);
                       }
                    }
                }
                else
                {
                    await UnauthorizedResponseAsync(httpContext);
                }
            }
    
            private static async Task UnauthorizedResponseAsync(HttpContext httpContext)
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Unauthorized");
                return;
            }

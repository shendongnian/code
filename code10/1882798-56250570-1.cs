          public async Task InvokeAsync(HttpContext httpContext, IConfiguration configuration)
                    {
               
                                var isAuthorized = Authorize();
            
                                if (isAuthorized)
                                {
                                   ..do your stuff
                                   await _next.Invoke(httpContext);
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

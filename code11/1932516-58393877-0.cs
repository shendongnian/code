    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var sessionManager = context.HttpContext.GetService<ISessionManager>();
            var endpoint = context.HttpContext.Features.Get<IEndpointFeature>()?.Endpoint;
            var allowAnon = endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null;
    
            if (!allowAnon && !sessionManager.IsCurrentTokenValid())
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var message = Encoding.UTF8.GetBytes("invalidToken");
                context.Response.OnStarting(async () =>
                {
                    await context.Response.Body.WriteAsync(message, 0, message.Length);
                });
            }
        }
    };

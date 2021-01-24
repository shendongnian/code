    services.AddAuthentication()
        .AddJwtBearer(options =>
        {
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = MyMethod()
            };
        });
       
    private static Func<AuthenticationFailedContext, Task> MyMethod()
    {
        return ctx =>
        {
            if (ctx.HttpContext.Request != null)
            {
                var logger = ctx.HttpContext.RequestServices.GetRequiredService<ILogger<Startup>>();
                logger.LogError(0, ctx.Exception, "Token validation failed");
            }
    
            return Task.CompletedTask;
        };
    }

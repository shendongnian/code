    OnAuthenticationFailed = context =>
    {
        
        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
        {
            var loggerFactory = context.HttpContext.RequestServices
                                .GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("Startup");
            logger.LogInformation("Token-Expired");
          
        }
        return System.Threading.Tasks.Task.CompletedTask;
    },

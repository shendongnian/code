    app.Use(async (context, next) =>
    {
        var host = context.Request.Host.ToString();
        if (true)
        {
            var result = await context.AuthenticateAsync("YourScheme");
            if (!result.Succeeded)
            {
                context.Response.StatusCode = 401;  
                return;
            }
        }
        ....
    
        await next();
    });

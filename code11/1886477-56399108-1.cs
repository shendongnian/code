    services.ConfigureApplicationCookie(options =>
    {
        options.SlidingExpiration = true;
        options.Events.OnRedirectToLogin = cxt =>
        {
            cxt.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = cxt =>
        {
            cxt.Response.StatusCode = 403;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToLogout = cxt => Task.CompletedTask;
    });

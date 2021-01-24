    services.ConfigureApplicationCookie(options =>
    {
        options.Events.OnRedirectToAccessDenied =
            options.Events.OnRedirectToLogin = context =>
            {
                if (context.Request.Method != "GET")
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.FromResult<object>(null);
                }
                context.Response.Redirect(context.RedirectUri);
                return Task.FromResult<object>(null);
            };
    });

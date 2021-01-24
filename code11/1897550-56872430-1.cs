    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(o =>
        {
            o.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = ctx =>
                {
                   var relativeRedirectUri = new Uri(ctx.RedirectUri).PathAndQuery;
                   context.Response.Headers["Location"] = relativeRedirectUri;
                   context.Response.StatusCode = 401;
                   return Task.CompletedTask;
               }
           };
       });

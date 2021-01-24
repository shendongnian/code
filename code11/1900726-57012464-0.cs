    .AddOpenIdConnect("oidc", "Open Id connect", options =>
    {
        // This event is fired when the user is about to be redirected to the login page.
        options.Events.OnRedirectToIdentityProvider = context =>
        {
            var validUrl = context.Request.Path.StartsWithSegments(new PathString("/secreturl"));                
            if (!validUrl)
            {
                context.Response.Redirect("http://localhost:5555");                            
                context.HandleResponse();
            }
            return Task.CompletedTask;
        };

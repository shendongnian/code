     services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle("Google", options =>
            {
                options.ClientId = Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = context =>
                    {
                        string domain = context.User.Value<string>("domain");
                        if (domain != "gmail.com")
                            throw new GoogleAuthenticationException("You must sign in with a gmail.com email address");
    
                        return Task.CompletedTask;
                    }
                };
            });

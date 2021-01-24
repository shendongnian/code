                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.LoginPath = new PathString("/account");
                    })
                .AddFacebook(facebookOptions =>
                    {
                        facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                        facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                        facebookOptions.CallbackPath = new PathString("/account/facebook");
                        facebookOptions.Events.OnCreatingTicket = ctx =>
                        {
                            ExternalLoginProviderHelper.LoginLocally(ctx.Principal);
                            return Task.CompletedTask;
                        };
                    })
                .AddGoogle(options =>
                    {
                        options.ClientId = Configuration["Authentication:Google:ClientId"];
                        options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                        options.Events.OnCreatingTicket = ctx =>
                        {
                            ExternalLoginProviderHelper.LoginLocally(ctx.Principal);
                            return Task.CompletedTask;
                        };
            });

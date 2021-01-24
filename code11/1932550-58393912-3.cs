    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.Name = configuration.Cookie.CoookieName;
                        options.LoginPath = configuration.Cookie.LoginPath;//This should login page path
                        options.LogoutPath = configuration.Cookie.LogoutPath;//This should logout page path
                        //options.Cookie.Expiration = configuration.Cookie.CookieExpiration;
                        options.ExpireTimeSpan = configuration.Cookie.ExpireTimeSpan;
                        options.SlidingExpiration = configuration.Cookie.SlidingExpiration;
                    });

     services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(config =>
                {
                    config.Cookie.Name = "login";
                    config.LoginPath = "/Account/Login";
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                });

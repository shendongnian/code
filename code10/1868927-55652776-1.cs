    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.LoginPath = "/Account/CustomLogin";
                options.Cookie.Name = "MyAuthCookieName";
            }
        );

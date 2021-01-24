    services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
        options =>
        {
            options.Cookie.Expiration = TimeSpan.FromMinutes(10);
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        });

    services
        .AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddFacebook(facebookOptions =>
        {
            facebookOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            facebookOptions.AppId = "xx";
            facebookOptions.AppSecret = "xxx";
        });

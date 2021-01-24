    services.AddAuthentication(sharedOptions =>
        {
            sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddAzureAd(options => Configuration.Bind("AzureAd", options))
        .AddCookie();
    services.AddHttpContextAccessor();

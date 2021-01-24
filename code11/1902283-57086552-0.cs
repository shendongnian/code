    services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
    .AddAzureAD(options => Configuration.Bind("AzureAd", options));
    services.Configure<CookieAuthenticationOptions>(AzureADDefaults.CookieScheme, options =>
    {
        options.Cookie.Name = "MyCookieName";
    });

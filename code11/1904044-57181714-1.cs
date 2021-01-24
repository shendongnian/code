    services
        .AddAuthentication(options =>
        {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "oidc";
        })
        .AddCookie("Cookies", options =>
        {
            options.Cookie.Name = ".MySite.Cookie";
        })
        .AddOpenIdConnect("oidc", "Open Id connect", options =>
        {
            options.SignInScheme = "Cookies";
            // etc

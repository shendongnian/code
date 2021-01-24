    services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => Configuration.Bind("AzureAd", options));
    services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
    {
        options.Events = new OpenIdConnectEvents
        {
            OnTokenValidated = ctx =>
            {
  
                // add claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var appIdentity = new ClaimsIdentity(claims);
                ctx.Principal.AddIdentity(appIdentity);
                return Task.CompletedTask;
            },
        };
    });

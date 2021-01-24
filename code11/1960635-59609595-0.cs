    services.AddAuthentication(AzureADB2CDefaults.BearerAuthenticationScheme)
        .AddAzureADB2CBearer(options => Configuration.Bind("AzureAdB2C", options));
    services.Configure<JwtBearerOptions>(AzureADB2CDefaults.JwtBearerAuthenticationScheme, options =>
    {
        options.TokenValidationParameters.ValidateIssuer = false; // accept several tenants (here simplified)
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = AuthenticationFailed
        };
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidAudience = "myAudience"
        };
    });

        services
        .AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          
        }).AddCookie()
        .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
        {
            options.SignInScheme = IdentityConstants.ExternalScheme;
            options.ClientId = ClientId;
            options.ClientSecret = ClientSecret;
            options.Authority = $"{baseAuthorityUrl}/{tenantId}/v2.0";
            options.CallbackPath = new PathString("/signin-oidc");
            options.Scope.Add("email");
            options.Scope.Add("profile");
            options.ResponseType = "code id_token";
            options.SaveTokens = true;
            options.GetClaimsFromUserInfoEndpoint = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = "name"
            };
        });

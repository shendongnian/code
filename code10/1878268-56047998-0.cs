       var issuer = "https://my-auth-provider-here/";
        IConfigurationManager<OpenIdConnectConfiguration> configurationManager = 
            new ConfigurationManager<OpenIdConnectConfiguration>($"{issuer}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
        OpenIdConnectConfiguration openIdConfig = configurationManager.GetConfigurationAsync(CancellationToken.None).Result;
        appBuilder.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
        {
            AuthenticationMode = AuthenticationMode.Active,
            TokenValidationParameters = new TokenValidationParameters()
            {
                AuthenticationType = "Bearer",
                ValidIssuer = issuer,
                ValidateAudience = false,
                IssuerSigningKeys = openIdConfig.SigningKeys
            }
        });

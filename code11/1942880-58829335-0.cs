    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = "Cookies"
    });
    app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
    {
        Authority = "https://localhost:44319/identity",
        ClientId = "mvc",
        Scope = "openid profile roles sampleApi",
        ResponseType = "id_token token",
        RedirectUri = "https://localhost:44319/",
        SignInAsAuthenticationType = "Cookies",
        UseTokenLifetime = false,
        Notifications = new OpenIdConnectAuthenticationNotifications
        {
            SecurityTokenValidated = async n =>
            {
            
            },
            RedirectToIdentityProvider = n =>
            {
            
                return Task.FromResult(0);
            }
        }
    });

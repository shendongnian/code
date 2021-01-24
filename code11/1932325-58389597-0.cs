    public void ConfigureAuth(IAppBuilder app)
    { 
    app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
    app.UseCookieAuthentication(new CookieAuthenticationOptions());
    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = clientId,
            Authority = authority,
            PostLogoutRedirectUri = postLogoutRedirectUri,
            RedirectUri = "https://www.contonso.com"
        });
        
        Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
    }

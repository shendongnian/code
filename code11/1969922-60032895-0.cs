    // Add cookie-based authentication to the request pipeline.
    // NOTE: Need to decompose this into its constituent components
    // app.UseIdentity();
    
    app.UseCookieAuthentication(null, IdentityOptions.ExternalCookieAuthenticationScheme);
    app.UseCookieAuthentication(null, IdentityOptions.TwoFactorRememberMeCookieAuthenticationScheme);
    app.UseCookieAuthentication(null, IdentityOptions.TwoFactorUserIdCookieAuthenticationScheme);
    app.UseCookieAuthentication(null, IdentityOptions.ApplicationCookieAuthenticationScheme,
        dataProtectionProvider: new DataProtectionProvider(
            new DirectoryInfo(@"c:\shared-auth-ticket-keys\")));

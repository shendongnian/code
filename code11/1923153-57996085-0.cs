    services.AddAuthentication(o =>
    {
        o.DefaultScheme = IdentityConstants.ApplicationScheme;
        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    }).AddIdentityCookies(o =>
    {
        o.ApplicationCookie.PostConfigure(cookie => cookie.SessionStore = new MemoryCacheTicketStore());
    });
    
    services.AddIdentityCore<IdentityUser>(o =>
    {
        o.Stores.MaxLengthForKeys = 128;
    }).AddDefaultUI()
    .AddDefaultTokenProviders();

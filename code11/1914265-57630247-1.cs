    services.AddAuthentication(o =>
    {
        o.DefaultScheme = IdentityConstants.ApplicationScheme;
        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies(o => { });
    services.AddIdentityCore<TUser>(o =>
    {
       o.Stores.MaxLengthForKeys = 128;
       configureOptions?.Invoke(o);
    })
        .AddDefaultUI()
        .AddDefaultTokenProviders();

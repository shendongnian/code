    IPublicClientApplication PublicClientApp = null;
    
    public Outlook()
    {
        PublicClientApp = PublicClientApplicationBuilder.Create(_AppID).Build();
        TokenCacheHelper.CacheFilePath = Program.Options.TokenCachePath;
        TokenCacheHelper.EnableSerialization(PublicClientApp.UserTokenCache);
    }

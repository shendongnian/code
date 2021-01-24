    IPublicClientApplication PublicClientApp = null;
    public Outlook()
    {
        PublicClientApp = PublicClientApplicationBuilder.Create(_AppID).Build();
        TokenCacheHelper.EnableSerialization(PublicClientApp.UserTokenCache);
    }

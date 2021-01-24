    public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri, Activity activity)
    {
        var authContext = new AuthenticationContext(authority);
        if (authContext.TokenCache.ReadItems().Count() > 0)
            authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
        var uri = new Uri(returnUri);
        var platformParams = new PlatformParameters(activity);
        var authResult = await authContext.AcquireTokenAsync(resource, clientId, uri, platformParams);
        return authResult;
    }

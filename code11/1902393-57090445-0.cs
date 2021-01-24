    public string ClientID => "01234567-89ab-cdef-0123-456789abcdef";
    // skipped some lines...
    private async Task<string> GetAccessToken(string authority, string resource, string redirectUri)
    {
        AuthenticationContext context = new AuthenticationContext(authority);
        AuthenticationResult tokenResult = await context.AcquireTokenAsync(resource, ClientID, RedirectUri, new PlatformParameters(PromptBehavior.RefreshSession));
        return tokenResult.AccessToken;
    }

    private async Task<string> GetUserTokenAsync(string userId, string connectionName, AppCredentials appCredentials)
    {
        var client = new OAuthClient(new Uri(OAuthClientConfig.OAuthEndpoint), appCredentials);
        var response = await client.UserToken.GetTokenAsync(userId, connectionName);
        return response.Token;
    }

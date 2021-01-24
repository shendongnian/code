    public async Task<IActionResult> GetAzureOAuthData([FromBody]dynamic parameters)
    {
        string userName = parameters.userName.ToString();
        string password = parameters.password.ToString();
        using (HttpClient client = new HttpClient())
        {
            var oauthEndpoint = new Uri("https://login.microsoftonline.com/organizations/oauth2/v2.0/token");
            var result = await client.PostAsync(oauthEndpoint, new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", _azureOptions.ClientId),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),

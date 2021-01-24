    private static async Task<string> SignInWithCustomTokenAsync(string customToken)
    {
        string apiKey = "..."; // see above where to get it. 
        var rb = new Google.Apis.Requests.RequestBuilder
        {
            Method = Google.Apis.Http.HttpConsts.Post,
            BaseUri = new Uri($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithCustomToken")
        };
        rb.AddParameter(RequestParameterType.Query, "key", apiKey);
        var request = rb.CreateRequest();
        var jsonSerializer = Google.Apis.Json.NewtonsoftJsonSerializer.Instance;
        var payload = jsonSerializer.Serialize(new SignInRequest
        {
            CustomToken = customToken,
            ReturnSecureToken = true,
        });
        request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
        using (var client = new HttpClient())
        {
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var parsed = jsonSerializer.Deserialize<SignInResponse>(json);
            return parsed.IdToken;
        }
    }

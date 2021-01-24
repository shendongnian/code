    static Lazy<HttpClient> client = new Lazy<HttpClient>(() => {
        HttpClientHandler clientHandler = new HttpClientHandler {
            Credentials = CredentialCache.DefaultCredentials,
            PreAuthenticate = true,
            AllowAutoRedirect = true
        };
        return new HttpClient(clientHandler);
    });
    private async Task<string> PostStatusRequestAsync(string status, string resource_url, string authHeader) {
        var request = new HttpRequestMessage(HttpMethod.Post, resource_url);
        request.Headers.TryAddWithoutValidation("Authorization", authHeader);
        request.Headers.Accept.Clear();
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var data = new Dictionary<string, string> {
            ["status"] = EncodingUtils.UrlEncode(status)
        };
                    
        request.Content = new FormUrlEncodedContent(data);
        using (HttpResponseMessage response = await client.Value.SendAsync(request)) {
            return response.StatusCode.ToString();
        }
    }

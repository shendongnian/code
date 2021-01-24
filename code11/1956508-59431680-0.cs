    public static async Task<T> GetRESTResult<T>(this GraphServiceClient client, string url)
    {
        // Create the request message and add the content.
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        // Authenticate (add access token) our HttpRequestMessage
        await client.AuthenticationProvider.AuthenticateRequestAsync(request);
        // Send the request and get the response.
        HttpResponseMessage response = await client.HttpProvider.SendAsync(request);
        // Process the response
        var jsonStr = response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(jsonStr.Result);
    }

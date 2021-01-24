    public static async Task<string> GetResponse(string page, Dictionary<String, String> arguments, bool IsPost = false)
    {
        HttpMethod Method = IsPost ? HttpMethod.Post : HttpMethod.Get;
        var request = new HttpRequestMessage(Method, page)
        {
            Content = new FormUrlEncodedContent(arguments)
        };
        HttpResponseMessage httpResponse = await Client.SendAsync(request).ConfigureAwait(false);
        if (httpResponse.IsSuccessStatusCode)
        {
            return await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
        return null;
    }

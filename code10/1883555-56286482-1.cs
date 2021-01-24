    public async void SendGetMethod(string url, Action<HttpResponseMessage> resopnse)
    {
        HttpClient client = new HttpClient();
        var headers = client.DefaultRequestHeaders;
        string header = "";
        if (!headers.UserAgent.TryParseAdd(header))
        {
            // throw new Exception("Invalid header value: " + header);
        }
        header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
        if (!headers.UserAgent.TryParseAdd(header))
        {
            throw new Exception("Invalid header value: " + header);
        }
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        Uri requestUri = new Uri(url);
        try
        {
            httpResponse = await client.GetAsync(requestUri);
            httpResponse.EnsureSuccessStatusCode();
            resopnse(httpResponse);
        }
        catch (Exception ex)
        {
            Debug.Write("Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message);
        }
    }

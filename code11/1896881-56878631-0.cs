    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri(url);
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, data);
    // The key part was the line below
    request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
    if (!string.IsNullOrEmpty(_access_token))
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _access_token);
    }
    HttpResponseMessage response = await client.SendAsync(request);

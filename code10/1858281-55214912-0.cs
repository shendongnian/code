    HttpClient client = new HttpClient();
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "APIurl");
    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "YourAccessToken");
    HttpResponseMessage response = await client.SendAsync(request);
    if (response.IsSuccessStatusCode)
    {
        String responseString = await response.Content.ReadAsStringAsync();
        ...
    }

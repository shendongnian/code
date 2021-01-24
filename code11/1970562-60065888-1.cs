    var client = new HttpClient();
    using var request = new HttpRequestMessage(HttpMethod.Post, "...");
    request.Content = new Dictionary<string, string>() { "grant_type", "client_credentials" };
    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", $"{Encoding.UTF8.GetBytes($"{id}:{secret}")}");
    HttpResponseMEssage = response = await client.PostAsync(request);
    response.EnsureSuccessStatusCode();
    var content = await response.Content.ReadAsStringAsync();

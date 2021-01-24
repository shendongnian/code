    using (var client = new HttpClient { BaseAddress = new Uri("https://baseUrl") })
    {
     var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes("username:password"));
     client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
     var response = await httpClient.PostAsync(requestUri, new StringContent(value));
    }

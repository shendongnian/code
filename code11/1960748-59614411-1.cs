    try
    {
        HttpClient client = _httpClientFactory.CreateClient("MyAPI");
        client.Timeout = new TimeSpan(0, 2, 0);
        //Create an HttpRequestMessage object and pass it into SendAsync()
        HttpRequestMessage message = new HttpRequestMessage();
        message.Headers.Add("Accept", "application/json");
        message.Content = new StringContent(JsonConvert.SerializeObject(myObj), System.Text.Encoding.UTF8, "application/json");
        message.Method = HttpMethod.Post;
        message.RequestUri = new Uri(client.BaseAddress.ToString() + "someapiendpoint";
        
        HttpResponseMessage response = await client.SendAsync(message);
        var result = await response.Content.ReadAsStringAsync();
        
    }
    catch (Exception ex)
    {
        //Log exception
    }
    return result;

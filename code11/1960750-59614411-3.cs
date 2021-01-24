    var result;
    try
    {
        HttpClient client = _httpClientFactory.CreateClient("MyAPI");
        //2 minute timeout on wait for response
        client.Timeout = new TimeSpan(0, 2, 0);
        //Create an HttpRequestMessage object and pass it into SendAsync()
        HttpRequestMessage message = new HttpRequestMessage();
        message.Headers.Add("Accept", "application/json");
        message.Content = new StringContent(JsonConvert.SerializeObject(myObj), System.Text.Encoding.UTF8, "application/json");
        message.Method = HttpMethod.Post;
        message.RequestUri = new Uri(client.BaseAddress.ToString() + "someapiendpoint");
        
        HttpResponseMessage response = await client.SendAsync(message);
        result = await response.Content.ReadAsStringAsync();
        //deserialize the result into proper object type
    }
    catch (Exception ex)
    {
        //Log exception
    }
    

    public static HttpClient GetClient(string token)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var yourContent = new
        {
            key1 = "value1",
            key2 = "value2"
        };
        var jsonContent = JsonConvert.SerializeObject(yourContent);
        var content = new StringContent(jsonContent, Encoding.ASCII, "application/json");
        var response = client.PostAsync(new Uri("https://api.sandbox.paypal.com/v2/checkout/orders"), content).Result;
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content;
            string responseString = responseContent.ReadAsStringAsync().Result;
        }
        return client;
    }

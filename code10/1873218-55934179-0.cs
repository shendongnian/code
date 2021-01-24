    var personalaccesstoken = "xxxxxxxxxx";
    var base64Token = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{personalaccesstoken}"));  
    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Token);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://{tfsserver}:8080/tfs/DefaultCollection/_apis/wit/wiql?api-version=1.0");
        requestMessage.Content = new StringContent("{\"query\": \"select [System.Id], [System.Title], [System.State] from WorkItems\"}", Encoding.UTF8, "application/json");
        using (HttpResponseMessage response = client.SendAsync(requestMessage).Result)
        {
            response.EnsureSuccessStatusCode();
        }    
    }

        HttpMessageHandler handler = new HttpClientHandler()
        {
        };
            
        var httpClient = new HttpClient(handler)
        {
             BaseAddress = new Uri(url),
             Timeout = new TimeSpan(0, 2, 0)
        };
            
        httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
            
        //This is the key section you were missing    
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("testing:123456");
        string val = System.Convert.ToBase64String(plainTextBytes);
        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
            
        var method = new HttpMethod("GET");
            
        HttpResponseMessage response = httpClient.GetAsync(url).Result;
        string content = string.Empty;
            
        using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, System.Text.Encoding.GetEncoding(_encoding)))
        {
             content = stream.ReadToEnd();
        }

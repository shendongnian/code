    _client = new HttpClient { BaseAddress = new Uri(ConfigManager.Api.BaseUrl), Timeout = new TimeSpan(0, 0, 0, 0, -1) };
    
          _client.DefaultRequestHeaders.Accept.Clear();
          _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    _client.DefaultRequestHeaders.Add("Bearer", "some token goes here");

    var _client = new HttpClient { BaseAddress = new Uri("some url goes here") };
    
          _client.DefaultRequestHeaders.Accept.Clear();
          _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    _client.DefaultRequestHeaders.Add("Bearer", "some token goes here");

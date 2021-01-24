     static async Task<string> GetWeatherAsync()
              {
                  using (var client = new HttpClient())
                  {
                      client.BaseAddress = new Uri("http://api.weather.gov");
                      client.DefaultRequestHeaders.Accept.Clear();
                      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                      client.DefaultRequestHeaders.Add("User-Agent", "web api client");
        
                      //var response = await client.GetAsync("https://api.weather.gov/points/39.7456,-97.0892");
                      var response = await client.GetAsync("/points/39.7456,-97.0892");
                      var responseString = await response.Content.ReadAsStringAsync();
        
                      return responseString;
                  }
              }

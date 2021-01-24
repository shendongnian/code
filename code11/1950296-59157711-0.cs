    public async void GetWeatherInfo(CityName city)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(city);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
    
            var uri = new Uri(string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=29d06aa8c8b3a8341ab876b124d7c&units=metric",json));
    
            var result = await httpClient.GetAsync(uri);
    
            if (result.IsSuccessStatusCode)
            {
                try
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(content);
            }}}

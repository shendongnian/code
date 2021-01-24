    public const string Endpoint = "api.openweathermap.org/data/2.5/weather";
    public async void GetWeatherBytCityName(string cityName)
    {
        using (var httpClient = new HttpClient())
        {
            var query = $"?q={cityName}";
            var response = await httpClient.GetAsync( $"{Endpoint}{query}");
        }
    }

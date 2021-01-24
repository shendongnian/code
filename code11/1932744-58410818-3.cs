    [HttpGet]
    public IEnumerable<WeatherForecast> Get([FromQuery] FilteringRequestModel request)
    {
        request.Initialize(_settings);
    
        var defaultType = request.Type;
    
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        })
        .ToArray();
    }

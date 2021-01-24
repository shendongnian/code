    public async IAsyncEnumerable<WeatherForecast> GetForecastAsync(DateTime startDate)
    {
        var rng = new Random();
        for (int i = 0; i < 77; i++)
        {
            yield return new WeatherForecast
            {
                Date = startDate.AddDays(i),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
            await Task.Delay(100);
        }
    }

    [HttpGet]
    public async Task<ActionResult<WeatherForecast[]>> Get() { //Note the array
        try {
            int userId = 3;
            if (HasAccess(userId) == false)
                return Forbid();
            var rng = new Random();
            WeatherForecast[] results = await Task.Run(() => Enumerable
                .Range(1, 5).Select(index => new WeatherForecast {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray()
            );
            return results;
        } catch (Exception ex) {
            throw;
        }
    }

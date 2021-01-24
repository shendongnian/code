    [HttpPost]
    public string WeatherForecasts([FromBody] string values)
    {
      // here you can check what has been passed to the values variable
      return values;
    }

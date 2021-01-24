    WeatherForecast Deserialize(string json)
    {
        var options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true
        };
        return JsonSerializer.Parse<WeatherForecast>(json, options);
    }
    class WeatherForecast {
        public DateTimeOffset Date { get; set; }
    
        // Always in Celsius.
        [JsonPropertyName("temp")]
        public int TemperatureC { get; set; }
    
        public string Summary { get; set; }
    
        // Don't serialize this property.
        [JsonIgnore]
        public bool IsHot => TemperatureC >= 30;
    }

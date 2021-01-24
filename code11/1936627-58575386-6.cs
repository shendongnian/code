    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        
        public int TemperatureCelcius { get; set; }
        public int TemperatureFahrenheit { get; set; }
        [JsonPropertyName("Description")]
        public string Summary { get; set; }
    }

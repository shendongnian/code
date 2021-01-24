    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    public class WeatherForecastDerived : WeatherForecast
    {
        public int WindSpeed { get; set; }
    }

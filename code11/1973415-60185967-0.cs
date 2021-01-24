csharp
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
        public string Summary { get; set; }
    }
I can then create an Extension class that contains methods for this specific type:
csharp
    public static class WeatherForecastExtensions
    {
        public static IQueryable<WeatherForecast> AddFilter(this IQueryable<WeatherForecast> queryable, string str)
        {
            return queryable
                .Where(forecast => forecast.Summary != null)
                .Where(forecast => forecast.Summary.Contains(str));
        }
    }
You can call it like this:
csharp
            var forecasts = new List<WeatherForecast>();
            var filtered = forecasts.AsQueryable()
                .AddFilter("cold")
                .ToList();
Keep in mind that these extension will only work for `IQueryable`s that contain a `Weatherforecast` object.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

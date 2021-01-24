string json = new WebClient().DownloadString("[** WEBSERVICE_URL **]");
WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
Console.WriteLine("Lat: " + weatherData.Lat);
Console.WriteLine("Lon: " + weatherData.Lon);
Console.WriteLine("\n");
public class WeatherData
{
    public string Lat { get; set; }
    public string Lon { get; set; }
    // OTHER PROPERTIES HERE ...
}

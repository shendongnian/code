    var data = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(@"C:\temp\Weather.json", Encoding.UTF8));
    public class Rootobject
    {
        public Metcheckdata metcheckData { get; set; }
        public DateTime feedCreation { get; set; }
        public string feedCreator { get; set; }
        public string feedModel { get; set; }
        public string feedModelRun { get; set; }
        public DateTime feedModelRunInitialTime { get; set; }
        public string feedResolution { get; set; }
    }
    public class Metcheckdata
    {
        public Forecastlocation forecastLocation { get; set; }
    }
    public class Forecastlocation
    {
        public Forecast[] forecast { get; set; }
        public string continent { get; set; }
        public string country { get; set; }
        public string location { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int timezone { get; set; }
    }
    public class Forecast
    {
        public string temperature { get; set; }
        public string dewpoint { get; set; }
        public string rain { get; set; }
        public string freezinglevel { get; set; }
        public string uvIndex { get; set; }
        public string totalcloud { get; set; }
        public string lowcloud { get; set; }
        public string medcloud { get; set; }
        public string highcloud { get; set; }
        public string humidity { get; set; }
        public string windspeed { get; set; }
        public string meansealevelpressure { get; set; }
        public string windgustspeed { get; set; }
        public string winddirection { get; set; }
        public string windletter { get; set; }
        public string icon { get; set; }
        public string iconName { get; set; }
        public string chanceofrain { get; set; }
        public string chanceofsnow { get; set; }
        public string dayOfWeek { get; set; }
        public string weekday { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string cumulusBaseHeight { get; set; }
        public string stratusBaseHeight { get; set; }
        public string dayOrNight { get; set; }
        public DateTime utcTime { get; set; }
    }

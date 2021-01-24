    public class weatherinfo
    {
        public int id { get; set; }
	    public string main { get; set; }
	    public string description { get; set; }
	    public string icon { get; set; }
    }
    public class WeatherMain
    {
       public coord coord { get; set; }
       public List<weatherinfo> weather { get; set; }
        public void display()
        {
            Console.WriteLine("lon: {0}", this.coord.lon);
            Console.WriteLine("lat: {0}", this.coord.lat);
            Console.WriteLine("id: {0}", string.Join(Environment.NewLine,this.weather.Select(c=>$"Weather:{c.main},Description:{c.description}")));
        }
    } 
     

    public class Response
    {
        public Country Country { get; set; }
    }
    public class City
    {
        public string CityName { get; set; }
        public string Unit { get; set; }
    }
    
    public class Country
    {
        public string CountryName { get; set; }
        public List<City> Cities { get; set; }
    }

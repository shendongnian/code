    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public List<City> Cities { get; set; }
    }
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string State { get; set; }
        public int Count { get; set; }
    }
    public class CountryInformation
    {
        public Country Country { get; set; }
        public int Population { get; set; }
    }

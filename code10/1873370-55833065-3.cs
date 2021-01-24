    public class Country {
        public string X { get; set; }
        public string Z { get; set; }
    }
    public class CountryYInfo {
        public string Y { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
    var country1 = new Country() { X = "A", Z = "C" };
    var countryInfo = new CountryYInfo { Y = "B", Country = country1 };
    var country2 = new Country() { X = "A", Z = "C" };
    context.Countries.Add(country1);
    context.Countries.Add(country2);

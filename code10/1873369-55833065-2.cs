    public class Country {
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }
    var country1 = new Country() { X = "A", Y = "B", Z = "C" };
    var country2 = new Country() { X = "A", Z = "C" };
    context.Countries.Add(country1);
    context.Countries.Add(country2);

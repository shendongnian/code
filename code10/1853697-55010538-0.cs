    class Car
    {
        public string LicensePlate {get; set;}
        public Color Color {get; set;}
        ...
    }
    class Volvo : Car
    {
        public string OriginalCountry => "Sverige";
    }

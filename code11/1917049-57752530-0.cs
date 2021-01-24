    public class RegionModel
    {
        public string Continent { get; set; }
        public string Country { get; set; }
        public override String ToString()
        {
           return $"{Country},{Continent}";
        }
    }

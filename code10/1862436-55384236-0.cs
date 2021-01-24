       public class GeoBias
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
        
        public class Summary
        {
            public string query { get; set; }
            public string queryType { get; set; }
            public int queryTime { get; set; }
            public int numResults { get; set; }
            public int offset { get; set; }
            public int totalResults { get; set; }
            public int fuzzyLevel { get; set; }
            public GeoBias geoBias { get; set; }
        }
        
        public class Name
        {
            public string nameLocale { get; set; }
            public string name { get; set; }
        }
        
        public class Classification
        {
            public string code { get; set; }
            public List<Name> names { get; set; }
        }
        
        public class Poi
        {
            public string name { get; set; }
            public string phone { get; set; }
            public string url { get; set; }
            public List<string> categories { get; set; }
            public List<Classification> classifications { get; set; }
        }
        
        public class Address
        {
            public string streetName { get; set; }
            public string municipalitySubdivision { get; set; }
            public string municipality { get; set; }
            public string countrySecondarySubdivision { get; set; }
            public string countrySubdivision { get; set; }
            public string postalCode { get; set; }
            public string countryCode { get; set; }
            public string country { get; set; }
            public string countryCodeISO3 { get; set; }
            public string freeformAddress { get; set; }
        }
        
        public class Position
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
        
        public class TopLeftPoint
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
        
        public class BtmRightPoint
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
        
        public class Viewport
        {
            public TopLeftPoint topLeftPoint { get; set; }
            public BtmRightPoint btmRightPoint { get; set; }
        }
        
        public class Position2
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
        
        public class EntryPoint
        {
            public string type { get; set; }
            public Position2 position { get; set; }
        }
        
        public class Result
        {
            public string type { get; set; }
            public string id { get; set; }
            public double score { get; set; }
            public double dist { get; set; }
            public string info { get; set; }
            public Poi poi { get; set; }
            public Address address { get; set; }
            public Position position { get; set; }
            public Viewport viewport { get; set; }
            public List<EntryPoint> entryPoints { get; set; }
        }
        
        public class RootObject
        {
            public Summary summary { get; set; }
            public List<Result> results { get; set; }
        }

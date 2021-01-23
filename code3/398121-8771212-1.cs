    public class PlacemakerResponse
    {
        public Document document { get; set; }
        public class Document
        {
            public List<AnotherPlacemaker> localScopes { get; set; }
        }
    }
    public class AnotherPlacemaker
    {
        public LocalScope LocalScope;
    }
        
    public class LocalScope
    {
        public String woeId { get; set; }
        public String name { get; set; }
        public Centroid centroid { get; set; }
        public class Centroid
        {
            public String latitude { get; set; }
            public String longitude { get; set; }
        }
    }

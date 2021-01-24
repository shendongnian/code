    public class Position
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public double Altitude { get; set; }
        }
    
        public class Geopoint
        {
            public Position Position { get; set; }
            public int AltitudeReferenceSystem { get; set; }
            public int GeoshapeType { get; set; }
            public int SpatialReferenceId { get; set; }
        }
    
        public class TimeZone
        {
            public string Id { get; set; }
            public string DisplayName { get; set; }
            public string StandardName { get; set; }
            public string DaylightName { get; set; }
            public string BaseUtcOffset { get; set; }
            public bool SupportsDaylightSavingTime { get; set; }
        }
    
        public class Landmarks
        {
            public bool freeLandmark { get; set; }
            public object Title { get; set; }
            public int Astro { get; set; }
        }
    
        public class ListaV01
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Rating { get; set; }
            public bool Reminder { get; set; }
            public bool Toast { get; set; }
            public Geopoint Geopoint { get; set; }
            public object Landmark { get; set; }
            public TimeZone TimeZone { get; set; }
            public string MainTag { get; set; }
            public int Version { get; set; }
            public Landmarks Landmarks { get; set; }
            public IList<object> Images { get; set; }
            public IList<object> URLs { get; set; }
            public IList<object> Tags { get; set; }
            public IList<object> Dates { get; set; }
            public bool Downloaded { get; set; }
            public bool Exportable { get; set; }
        }
    
        public class MyDB
        {
            public string Version { get; set; }
            public DateTime Date { get; set; }
            public IList<ListaV01> Lista_v0_1 { get; set; }
        }

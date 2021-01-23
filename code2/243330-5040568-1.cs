     namespace GoogleMapsSample
    {
        [DataContract]
        public class GeoResponse
        {
            [DataMember(Name = "status")]
            public string Status { get; set; }
            [DataMember(Name = "results")]
            public CResult[] Results { get; set; }
    
            [DataContract]
            public class CResult
            {
                [DataMember(Name = "geometry")]
                public CGeometry Geometry { get; set; }
    
                [DataContract]
                public class CGeometry
                {
                    [DataMember(Name = "location")]
                    public CLocation Location { get; set; }
    
                    [DataContract]
                    public class CLocation
                    {
                        [DataMember(Name = "lat")]
                        public double Lat { get; set; }
                        [DataMember(Name = "lng")]
                        public double Lng { get; set; }
                    }
                }
            }
    
            public GeoResponse()
            { }
        }
    
    
    }

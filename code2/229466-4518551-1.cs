    [DataContract]
    public class mapResult
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        //public IList<Resultdetail> result { get; set; }
        // Misspelt property name and use of interface rather than concrete type
        public List<Resultdetail> results { get; set; }
    }
    [DataContract]
    public class Resultdetail
    {
        [DataMember]
        public List<string> types { get; set; }
        [DataMember]
        public string formatted_address { get; set; }
        [DataMember]
        public List<object> address_components { get; set; }
        [DataMember]
        //public List<Geometry> geometry { get; set; }
        // Json does not contain an array/list of these
        public Geometry geometry { get; set; }
    }
    [DataContract]
    public class Geometry
    {
        [DataMember]
        //public List<GeoLocation> location { get; set; }
        // Json does not contain an array/list of these
        public GeoLocation location { get; set; }
        [DataMember]
        public string location_type { get; set; }
        [DataMember]
        // public List<object> viewport { get; set; }  
        // Json does not contain an array/list of these
        public object viewport { get; set; }
        [DataMember]
        //public List<object> bounds { get; set; }
        // Json does not contain an array/list of these
        public object bounds { get; set; }
    }

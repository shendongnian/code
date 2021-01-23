    [DataContract]
    public class Place
    {
        [DataMember]
        public decimal Latitude { get; set; }
        [DataMember]
        public decimal Longitude { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

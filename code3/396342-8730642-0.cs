    [DataContract]
    public class Deal
    {
        [DataMember(Name="name")]
        public string Store { get; set; }
        [DataMember(Name="deals")]
        public Offer[] Offers {get; set;}
        [DataMember(Name="geometry")]
        public GeoCoordinate Location { get; set; }
    }
    [DataContract]
    public class Offer
    {
        [DataMember(Name="desc")]
        public string deal { get; set; }
    }

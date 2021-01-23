    [Serializable]
    public class RatePlans: List<RatePlan>
    {
        [XmlAttribute]
        public string HotelCode { get; set; }
    }

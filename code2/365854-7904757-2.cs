    [Serializable]
    [XmlRoot("Root")]
    public class Root 
    {
        public RatePlans RatePlans { get; set; }
    }
    [Serializable]
    public class RatePlans
    {
        [XmlAttribute]
        public string HotelCode { get; set; }
    	
        [XmlElement("RatePlan")]
    	public List<RatePlan> Items = new List<RatePlan>();
    }

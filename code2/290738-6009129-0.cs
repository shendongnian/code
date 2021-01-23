    [XmlRoot("locations")]
    public class Locations
    {
        [XmlElement("location")]
        public List<SnowPark> Parks {get;set;}
    }

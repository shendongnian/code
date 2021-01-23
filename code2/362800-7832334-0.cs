    [Serializable, XmlRoot("person")]
    public class FooUserProfile
    {
        /* The other members... */
    
    
        [XmlArray("positions")]
        [XmlArrayItem("position")]
        public List<FooPosition> Positions { get; set; }
    }

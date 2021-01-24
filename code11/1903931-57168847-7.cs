    public class xcase
    {
        public String id;
        public String name;
        public Property[] properties;...
    }
    public class suite
    {
        [XmlElement(ElementName = "case")]
        public xcase[] cases {get; set; } 
        ....
    }

    [XmlTypeAttribute(AnonymousType=true)]
    [XmlRootAttribute(Namespace="", IsNullable=false)]
    public class foo {
        [XmlElementAttribute("barlist")]
        public List<fooBarlist> barlist { get; set; }
    }
    
    [XmlTypeAttribute(AnonymousType=true)]
    public class fooBarlist {
        [XmlElementAttribute("bar")]
        public List<fooBarlistBar> bar { get; set; }
        [XmlAttribute()]
        public byte id { get; set; }
    }
    
    [XmlTypeAttribute(AnonymousType=true)]
    public class fooBarlistBar {
        [XmlAttribute()]
        public byte number { get; set; }
        [XmlAttribute()]
        public string value { get; set; }
    }

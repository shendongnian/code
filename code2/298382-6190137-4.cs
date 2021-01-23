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
        [XmlAttributeAttribute()]
        public byte id { get; set; }
    }
    
    [XmlTypeAttribute(AnonymousType=true)]
    public class fooBarlistBar {
        [XmlAttributeAttribute()]
        public byte number { get; set; }
        [XmlAttributeAttribute()]
        public string value { get; set; }
    }

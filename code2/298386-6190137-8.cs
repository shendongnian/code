    [XmlType(AnonymousType=true)]
    [XmlRoot(Namespace="", IsNullable=false)]
    public class foo {
        [XmlElement("barlist")]
        public List<fooBarlist> barlist { get; set; }
    }
    
    [XmlType(AnonymousType=true)]
    public class fooBarlist {
        [XmlElement("bar")]
        public List<fooBarlistBar> bar { get; set; }
        [XmlAttribute()]
        public byte id { get; set; }
    }
    
    [XmlType(AnonymousType=true)]
    public class fooBarlistBar {
        [XmlAttribute()]
        public byte number { get; set; }
        [XmlAttribute()]
        public string value { get; set; }
    }

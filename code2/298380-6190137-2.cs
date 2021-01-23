    [XmlTypeAttribute(AnonymousType=true)]
    [XmlRootAttribute(Namespace="", IsNullable=false)]
    public class foo 
    {
        public fooBarlist barlist { get; set; }
    }
    [XmlTypeAttribute(AnonymousType=true)]
    public class fooBarlist 
    {
        [XmlElementAttribute("bar")]
        public List<fooBarlistBar> bar { get; set; }
        [XmlAttributeAttribute()]
        public int id { get; set; }
    }
    [XmlTypeAttribute(AnonymousType=true)]
    public class fooBarlistBar 
    {
        [XmlAttributeAttribute()]
        public int number { get; set; }
        [XmlAttributeAttribute()]
        public string value { get; set; }
    }

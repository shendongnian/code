    [XmlType("FooElement")]
    public class Foo {
    
        [XmlAttribute("Type")]
        public string fooType;
    
        [XmlElement("Name")]
        public string Name;
    
        [XmlIgnore()]
        public Bar BarObject;
        [XmlElement("Message")]
        public string BarMessage
        {
           get {
              return this.Bar.BarString;
           }
           set {
              this.Bar.BarString = value;
           }
    }
    
    public class Bar {
        public string BarString;
    }

    [XmlRoot("FooList")]
    public class FooListContainer
    {
        public string SomeMessage { get; set; }
    
        [XmlElement("Foo")]
        public List<Foo> Foos { get; set; }
    }

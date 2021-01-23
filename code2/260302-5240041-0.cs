    namespace Example
    {
        [XmlRoot("foos")]    
        class Foos
        {
            public Foos() {}
            [XmlElement("foo")]
	        public List<Foo> FooList {get; set;}
        }
    }

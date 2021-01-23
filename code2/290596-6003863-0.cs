    public class Foo {
        public BarWrapper Bars {get;set;}
    }
    public class BarWrapper {
        private readonly List<Bar> bars = new List<Bar>();
        [XmlElement("Bar")]
        public List<Bar> Items {get{return bars;}}
        [XmlAttribute]
        public int Baz {get;set;}
    }
    public class Bar {...}

    [XmlRoot("Foo")]
    public class Foo
    {
        private List<Bar> bar_ = new List<Bar>();
        [XmlElement("Something")]
        public string Something { get; set; }
        [XmlElement("Bar")]
        public List<Bar> Bars { get { return bar_; } }
    }

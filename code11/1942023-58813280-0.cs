    [XmlRoot]
    public class TestData
    {
        [XmlElement]
        public input[] TestChild { get; set; }
    }
    public class input
    {
        [XmlElement]
        public string name { get; set; }
        [XmlElement]
        public string value { get; set; }
    }

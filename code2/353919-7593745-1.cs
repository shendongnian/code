    [XmlRoot("TestObject")]
    class TestClass {
        public int TestElement1 { get; set; }
        [XmlElement("TestElement2")]
        public int Element { get; set; }
    }

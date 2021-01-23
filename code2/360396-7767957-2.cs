    [XmlRoot("Document")]
    public class TestWrapper {
        private readonly List<TestGroup> tests = new List<TestGroup>();
        [XmlArray("Tests"), XmlArrayItem("Test")]
        public List<TestGroup> Tests { get { return tests; } }
    }
    
    public class TestGroup {
        [XmlElement("Name")] public string TestName { get; set; }
        [XmlElement("Type")] public string TestType { get; set; }
        [XmlElement("Result")] public string TestResult { get; set; }
    }

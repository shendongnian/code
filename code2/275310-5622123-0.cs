    [XmlRoot("TestFile")]
    public class TestFile
    {
        [XmlElement(ElementName = "string", Type = typeof(ValueString))]
        [XmlElement(ElementName = "bool", Type = typeof(ValueBool))]
        public List<Test> Tests;
    }

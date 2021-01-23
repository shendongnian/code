    [XmlRootAttribute("TestFile", IsNullable = false)]
    public class TestFile
    {
        [XmlArrayAttribute("ParameterCollection")]
        public Parameter[] Parameters;
    }
    public class Parameter
    {
        [XmlAttribute("type")]
        public string ObjectType;
    
        [XmlText]
        public string ObjectValue;
    }

    [XmlRoot(ElementName = "SOME_OVERRIDDEN_NAME")]
    public class TestXml : IList<TestXmlElement>
    {
        private List<TestXmlElement> _innerList = new List<TestXmlElement>();
        public TestXmlElement this[int index] { get => _innerList[index]; set => _innerList[index] = value; }
        public int Count => _innerList.Count;
        public bool IsReadOnly => false;
        
        -- snip rest of IList members
    }

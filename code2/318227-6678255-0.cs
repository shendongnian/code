    [Serializable]
    public class Person
    {
        public string Name { get; set; }
    
        [XmlElement(ElementName = "")]
        public List<string> AddressLine { get; set; }
    }

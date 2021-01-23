    [Serializable]
    public class Person
    {
        public string Name { get; set; }
    
        [XmlElement]
        public List<string> AddressLine { get; set; }
    }

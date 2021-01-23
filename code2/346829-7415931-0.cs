    [Serializable]
    public class MyClass
    {
        public string SerializeMe { get; set; }
        
        [XmlIgnore]
        public string DONTSerializeMe { get; set; }
    }

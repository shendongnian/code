    [Serializable]
    public class MyObject
    {
        public string SerializeMe { get; set; }
        
        [XmlIgnore]
        public string DONTSerializeMe { get; set; }
    }

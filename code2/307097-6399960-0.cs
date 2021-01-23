    [Serializable]
    public class LogItem
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    
        public LogItem(string key, string value)
        {
            Name = key; Value = value;
        }
    
        public LogItem() { }
    }

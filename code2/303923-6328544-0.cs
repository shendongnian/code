    [Serializable]
    public class Foo
    {
        // Used for current use
        [XmlIgnore]
        public DateTime Date { get; set; }
    
        // For serialization.
        [XmlElement]
        public String ProxyDate
        {
            get { return Date.ToString("<wanted format>"); }
            set { Date = DateTime.Parse(value); }
        }
    }

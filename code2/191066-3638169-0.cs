    public class CurrentCondition
    {
        [XmlAttribute("iconUrl")
        public string IconUrl { get; set; }
    
        // Representation of Inner Text:
        [XmlText]
        public string ConditionValue {get;set;}
    }

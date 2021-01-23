    public class EpochTime {
        public enum TimeType {
           [XmlEnum("epoch_seconds")] Seconds
        }
        [XmlAttribute("type")] public TimeType Type {get;set;}
        [XmlText] public string Text {get;set;}
        [XmlIgnore] public DateTime Value {
            get { /* your parse here */ }
            set { /* your format here */ }
        }
    }

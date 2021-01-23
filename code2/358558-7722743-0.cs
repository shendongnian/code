    public class Alerts
    {
        [XmlElement("AlertOne")]
        public Alert AlertOne { get; set; }
    }
    public class Alert
    {
        [XmlText]
        public int Parameter { get; set; }
        [XmlAttribute("Enabled")]
        public bool Enabled { get; set; }
    }

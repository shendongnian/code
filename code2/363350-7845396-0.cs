    [XmlRoot("events")]
    public class Events {
        [XmlElement("event")]
        public List<Event> Items {get;set;}
    }
    public class Answer {
        [XmlAttribute("cost")]
        public int Cost {get;set;}
        [XmlText]
        public string Text {get;set;}
    }
    public class Event {
        [XmlElement("answer")]
        public List<Answer> Answers {get;set;}
        [XmlElement("text")]
        public string Text {get;set;}
    }

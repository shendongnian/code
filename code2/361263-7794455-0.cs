     [XmlRoot("form")]
        public class Form
        {
            [XmlElement("question")]
            public List<Question> Questions { get; set; }
    
            public Form()
            {
                Questions = new List<Question>();
            }
        }
        public struct Question
        {
            [XmlAttribute("id")]
            public string ID { get; set; }
    
            [XmlElement("answer")]
            public string Answer { get; set; }
        }

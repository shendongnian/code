    [XmlRoot(ElementName = "field")]
        public class Field
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }
    
        [XmlRoot(ElementName = "message")]
        public class Message
        {
            [XmlElement(ElementName = "field")]
            public List<Field> Field { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "group")]
            public Group Group { get; set; }
        }
    
        [XmlRoot(ElementName = "group")]
        public class Group
        {
            [XmlElement(ElementName = "field")]
            public List<Field> Field { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }
    
        [XmlRoot(ElementName = "messages")]
        public class Messages
        {
            [XmlElement(ElementName = "message")]
            public List<Message> Message { get; set; }
        }

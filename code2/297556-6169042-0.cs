    [Serializable()]
    public class AnswerItem
    {
        [XmlAttribute("Id")]
        public Guid QuestionId { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }

    [Serializable]
        public class TestObj
        {
            [XmlElement(ElementName = "question")]
            [XmlElement(typeof(QuestionObj))]
            public List<QuestionObj> Questions { get; set; }
    
            public int Id { get; set; }
            public string Name;
        }
    
    [Serializable]
        public class QuestionObj
        {
            [XmlElement(ElementName = "stem")]
            public string Stem { get; set; }
    
    
            [XmlElement("answers")]
            public List<AnswerObj> Answers { get; set; }
    
            public int TestId { get; set; }
            public int Id { get; set; }
        }
    
    [Serializable]
       public class AnswerObj
        {
            [XmlElement(ElementName = "answer")]
            public string Answer { get; set; }
    
           public int Id { get; set; }
           public int StemId { get; set; }
        }

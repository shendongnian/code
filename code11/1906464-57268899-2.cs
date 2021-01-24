    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        public int SectionID { get; set; }
        public List<Messages> messages { get; set; }
    }
    public class Messages
    {
        public int MessagesID { get; set; }
        public string MessagesName { get; set; }
        public int QuestionID { get; set; }
    }
    public class Section
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public List<Question> questions { get; set; }
    }

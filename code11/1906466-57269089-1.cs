    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        public int SectionID { get; set; }
        public IEnumerable<Messages> Messages { get; set; }
    }
    public class Section
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }

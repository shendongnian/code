    public class Question
    {
        public int Id { get; set; }
        public QuestionStatus Status { get; set; }
    }
    
    public class QuestionHistory
    {
        public Question Question { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
     
        public User Author { get; set; }
        public DateTime Created { get; set; }
        public IList<Tag> Tags { get; set; }
    }

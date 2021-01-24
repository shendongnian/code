    public class Form
    {
        [Key]
        public int Id { get; set; }
        public List<Topic> Topics { get; set; }
    }
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public List<Question> Questions { get; set; }
        public int FormId { get; set; }
        [ForeignKey("FormId")]
        public Form Form { get; set; }
    }
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }
    }

    public class Question
    {
        [Key]
        public int questionID { get; set; }
        public string questionTitle { get; set; }
        public List<QuestionGroup> QuestionGroups { get; set; }
        //public List<Group> Groups { get; set; }
        //public string GroupID { get; set; }
    }
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public List<QuestionGroup> QuestionGroups { get; set; }
    }
    public class QuestionGroup
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
    public class GetQuestionViewModel
    {
        public int questionID { get; set; }
        public string questionTitle { get; set; }
        public ICollection<Group> QuestionGroups { get; set; }
    }

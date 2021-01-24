    public class Question
    {
        [Key]
        public int questionID { get; set; }
        public string questionTitle { get; set; }
    
        public int GroupID { get; set; }
        [ForeignKey("Group_ID")]
        public virtual Group Group { get; set; }
    }

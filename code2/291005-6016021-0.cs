    public class UserAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
    } 

    public class Setting
    {
        public virtual Guid Id { get; set; }
        public virtual Student Student { get; set; }
    }
    
    public class Student
    {
        public virtual Guid Id { get; set; }
        public virtual Setting Setting { get; set; }
    }

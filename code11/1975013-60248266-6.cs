    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey(nameof(Subject))]
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; } //Navigation Property
    }

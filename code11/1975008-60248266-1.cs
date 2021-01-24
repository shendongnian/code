    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

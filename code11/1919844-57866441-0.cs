    public class Subject
    {
        [Key]
        public string Id { get; set; } // ID for the Subject
        // some codes omitted ...
        public string StudentId { get; set; } // FK to the student.
        [ForeignKey("StudentId")]
        public Student student {get; set;}
    }

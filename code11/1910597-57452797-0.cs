     public class Notes {
        public int NotesId { get; set; }
         [Required]
        public string NoteValue { get; set; }
         [Required]
        public string Subject { get; set; }
        
        public Student Student { get; set; }
        [ForeignKey ("Student")]        
        public int StudentId { get; set; }
    }

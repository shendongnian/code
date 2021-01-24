    public class Lecturer
    {
         // Lecturer's own attributes
         public int lecturerId { get; set; }
         public string lecturerName { get; set; }
         // FK attribute
         public int courseId { get; set; }
         // FK navigation property
         public virtual Course Course { get; set; }
    }

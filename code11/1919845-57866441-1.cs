    public class Student
    {
       [Key]
       public int Id { get; set; } 
    
       public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
    
    public class Subject
    {
       [Key]
       public int Id { get; set; } 
    
       public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }

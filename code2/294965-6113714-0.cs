    public class Student
    {
        public string Name {get; set;}
        
        public virtual ICollection<Course> Courses {get; set;}
    }

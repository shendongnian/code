    public class Course
    {
       public string Name { get; set; }
       public string Teacher { get; set; }
    }
    
    public class Student
    {
      public string Name { get; set; }
      public int Age { get; set; }
      public ReadOnlyCollection<Course> Courses { get; set; }
    }

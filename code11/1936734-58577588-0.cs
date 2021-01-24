    public class Student
    {
      public override string ToString() => $"Course Name: {this.CourseName} ({this.CourseID})";
      public string Name { get; set; }
      public int Age { get; set; }
      public string Course { get; set; }
      public string CourseID { get; set; }
      public string CourseName { get; set; }
      public DateTime JoiningDate { get; set; }
    }

    public class CourseDisplay
    {
       private Course course; 
       public CourseDisplay(Course course)
       {
           this.course = course;
       }
       public string CourseName 
       { 
           get { return course.Name; } 
       }
       
       public string UserName 
       { 
           get { return course.User.Name;} 
       }
    }

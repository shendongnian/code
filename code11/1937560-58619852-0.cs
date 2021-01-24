    public class UserCourse
    {
       //[Key]
       public string UserId { get; set; }
       public VODUser User { get; set; }
       public int CourseId { get; set; }
       public Course Course { get; set; }
    }

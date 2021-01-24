    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<TagCourse> TagCourses{ get; set; }
    }
    
    public class TagCourse
    {
       public int CourseId {get;set; }
       public int TagId {get;set; }
       public string Details {get;set; }
    }
    
    public class Tag
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public ICollection<TagCourse> TagCourses { get; set; }
    }

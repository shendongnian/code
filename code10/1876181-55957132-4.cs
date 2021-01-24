    public class RemindUsersViewModel
    {
        public List<CourseModel> Courses { get; set; }        
    }
    public class CourseModel
    {
        public List<SelectListItem> UsersCompleted { get; set; } 
        public List<SelectListItem> UsersNotCompleted { get; set; }
        public Course Course { get; set; }
    }

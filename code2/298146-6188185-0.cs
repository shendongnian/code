    public class Country
    {
        public ICollection<State> States { get; set; }
    }
    public class State
    {
        public ICollection<School> Schools { get; set; }
    }
    public abstract class School { ...  }
    public class ElementarySchool : School { ... }
    public class HighSchool : School
    {
        public ICollection<DrivingCourse> DrivingCourses { get; set; }
    }
    public class DrivingCourse { ... }

    public class GradeLevel
    {
        public int Id { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class Course
    {
        public int Id { get; set; }
        public int GradeLevelId { get; set; }
        public GradeLevel GradeLevel { get; set; }
        public List<Unit> Units { get; set; }
    }
    public class Unit
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
    public class Lesson
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
    public class Assignment
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public List<AssignmentStudent> AssignmentStudents { get; set; }
    }
    public class AssignmentStudent
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public decimal ObtainedMarks { get; set; }
    }
    public class TestDbContext : DbContext
    {
        public DbSet<AssignmentStudent> AssignmentStudents { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<GradeLevel> GradeLevels { get; set; }
    }

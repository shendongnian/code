    public abstract class CourseBase<T> where T : SubjectBase
    {
        public virtual IEnumerable<T> Subjects
        {
            get { return new List<T>(); }
        }
    }
    public abstract class SubjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValidityPeriod { get; set; }
    }
    public class LocalCourse : CourseBase<LocalCourseSubject>
    {
        public override IEnumerable<LocalCourseSubject> Subjects
        {
            get { throw new NotImplementedException(); }
        }
    }

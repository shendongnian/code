    public interface ICourse<TSubject>
    {
       IEnumerable<TSubject> Subjects { get; }
    }
    
    public abstract class CourseBase<TSubject> 
       : BaseObject, 
         ICourse<TSubject>
    {
        public IEnumerable<TSubject> Subjects
        {
            get { return new List<TSubject>(); }
        }   
    }
    public class LocalCourse 
       : CourseBase<LocalCourseSubject>
    {
    }

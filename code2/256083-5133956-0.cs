    public class TutorViewModel
    {
         public IEnumerable<User> Tutors { get; set; }
         // the pair CourseId, UserId is the relation in CourseTutors so we only
         // need to keep it once, not once per user.
         public int CourseId { get; set; } 
         public string CourseName { get; set; }
    }
    public TutorViewModel GetTutorByCourseId(int courseId)
    {
        var model = new TutorViewModel { CourseId = courseId };
        using (leDataContext db = new leDataContext())
        {
            try
            {
                model.CourseName = db.Courses
                                     .First( c => c.CourseId == courseId )
                                     .Name;
                model.Users = db.CourseByTutors
                                .Where( c => c.Id == courseId )
                                .Join( db.Users,
                                       c => c.TutorId,
                                       u => u.Id,
                                       (c,u) => u );
                return model;
            }
            catch (Exception ex)
            {
                Logger.Error(typeof(User), ex.ToString());
                throw;
            }
        }
    }

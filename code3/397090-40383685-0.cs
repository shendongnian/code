      class StudenRepository
      {
         dbcontext ctx;
         StundentRepository(dbcontext ctx)
         {
           this.ctx=ctx;
         }
         public void EnrollCourse(int courseId)
         {
           this.ctx.Students.Add(new Course(){CourseId=courseId});
         }
      }
      class TeacherRepository
      {
         dbcontext ctx;
         TeacherRepository(dbcontext ctx)
         {
           this.ctx=ctx;
         }
         public void EngageCourse(int courseId)
         {
           this.ctx.Teachers.Add(new Course(){CourseId=courseId});
         }
      }
      
      public class MyunitOfWork
      {
         dbcontext ctx;
         private StudentRepository _studentRepository;
         private TeacherRepository _teacherRepository;
         public MyunitOfWork(dbcontext ctx)
         {
           this.ctx=ctx;
         }
        public StudentRepository StundetRepository
        {
           get
           {       
                 if(_studentRepository==null)
                    _stundentRepository=new StundetRepository(this.ctx);
                return _stundentRepository;    
           }
        }
        public TeacherRepository TeacherRepository 
        {
           get
           {       
                 if(_teacherRepository==null)
                    _teacherRepository=new TeacherRepository (this.ctx);
                return _teacherRepository;    
           }
        }
       
        public void Commit()
        {
             this.ctx.SaveChanges();
        }
      }
    //some controller method
    public void Register(int courseId)
    {
      using(var uw=new MyunitOfWork(new context())
      {
        uw.StudentRepository.EnrollCourse(courseId);
        uw.TeacherRepository.EngageCourse(courseId);
        uw.Commit();
      }
    }

      public interface IStudentRepository:IDataRepository
        {
             void AddGuardian(Gurdian gurdian, int studentId,Action<Student> callBack);
             void SaveStudent(Student student, Gurdian gurdian,Action<Student>callBack);         
             void GetPrimaryGurdian(int studentId,Action<Gurdian> callBack );
            
        }
 
    [Export(typeof(IStudentRepository))]
        [PartCreationPolicy(CreationPolicy.NonShared)]
        public class StudentRepository : Repository<StudentContext>, IStudentRepository
        {
            public void AddGuardian(Gurdian gurdian, int studentId, Action<Student> callBack)
            {
               FindAsync<Student>(studentId, (student) =>
               {
                   student.Gurdians.Add(gurdian);
                   UpdateAsync(student, callBack);
               });
            }
    
            public void SaveStudent(Student student, Gurdian gurdian, Action<Student> callBack)
            {
              student.Gurdians.Add(gurdian);
                AddAsync(student, callBack);
            }
    
            public void GetPrimaryGurdian(int studentId, Action<Gurdian> callBack)
            {
               FindAsync<Student>(studentId,(student)=> { callBack(student.PrimaryGurdian); });
            }
        }

    public class StudentService
    {
      private IStudentRepository _studentRepository;
    
      public StudentService(IStudentRepository studentRepository)
      {
    	_studentRepository = studentRepository;
      }
    }
    
    public interface IStudentRepository
    {
      void Save(Student student);
      Student[] GetStudents();
    }
    
    public class StudentRepository : IStudentRepository
    {
     ... implement the methods defined in the interface ...
    }

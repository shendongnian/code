class Program
{
	static void Main(string[] args)
	{
		StudentRepository studentRepository = new StudentRepository();
		IProcessor<Student> processor = new Processor<Student>(studentRepository);
		processor.Process(new Student());
	}
}
public interface IProcessor<T> where T : new()
{
	bool Process(T t);
}
public class Processor<T> : IProcessor<T> where T : new()
{
	IRepository<T> _repo;
	public Processor(IRepository<T> repo)
	{
		_repo = repo;
	}
	public bool Process(T t)
	{
		_repo.Save(t);
		return true;
	}
}
public interface IRepository<T> where T : new()
{
	void Save(T e);
}
public class StudentRepository : IRepository<Student>
{
	public void Save(Student e)
	{
		return;
	}
}
public class TeacherRepository : IRepository<Teacher>
{
	public void Save(Teacher e)
	{
		return;
	}
}
public class Student { }
public class Teacher { }

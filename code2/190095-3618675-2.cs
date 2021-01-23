   	public class Students : ReadOnlyCollection<Student>
	{
		public Students(IList<Student> students) : base(students)
		{}
		public IEnumerable<string> Names
		{
			get { return this.Select(x => x.Name); }
		}
		public IEnumerable<string> Cities
		{
			get { return this.Select(x => x.City); }
		}
	}
	public class Student 
	{
                  public Student(string name, string city, int age)
                  {
                      this.Name = name;
                      this.City = city;
                      this.Age = age;
                  }
		public string Name { get; private set; } 
		public string City { get; private set; } 
		public int Age { get; private set; } 
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Student> students = new List<Student>();
			students.Add(new Student("Stud1", "City1",20));
			students.Add(new Student("Stud2", "City2",46));
			students.Add(new Student("Stud3", "City3",66));
			students.Add(new Student("Stud4","city4", 34));
			Students readOnlyStudents = new Students(students);
			foreach (string studentCity in readOnlyStudents.Cities)
			{
				Console.WriteLine(studentCity);
			}
			foreach (string studentName in readOnlyStudents.Names)
			{
				Console.WriteLine(studentName);
			}
		} 
	}

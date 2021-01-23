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
	public struct Student 
	{
		public string Name { get; set; } 
		public string City { get; set; } 
		public int Age { get; set; } 
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Student> students = new List<Student>();
			students.Add(new Student { Age = 20, Name = "Stud1", City = "City1" });
			students.Add(new Student { Age = 46, Name = "Stud2", City = "City2" });
			students.Add(new Student { Age = 32, Name = "Stud3", City = "City3" });
			students.Add(new Student { Age = 34, Name = "Stud4", City = "city4" });
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

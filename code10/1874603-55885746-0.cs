	public class Student
    {
		public string Name { get; set; }
		public string Address { get; set; }
    }
	public class ListOfStudents
	{
		public Student student { get; set; }
	}
	public static ListOfStudents GetListOfStudents()
	{
		List<Student> students = new List<Student>();
		Student student = new Student
		{
			Name = "Mike",
			Address = "Main St"
		};
		students.Add(student);
		ListOfStudents listOfStudents = new ListOfStudents
		{
			student = student
		};
		return listOfStudents;
	}

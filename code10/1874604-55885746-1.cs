     public class Student
	 {
		public string Name { get; set; }
		public string Address { get; set; }
	 }
	 public class ListOfStudents
	 {
		public Student[] Students = new Student[100];
		public Student this[int index]
		{
			get { return Students[index]; }
			set { Students[index] = value; }
		}
	 }
	

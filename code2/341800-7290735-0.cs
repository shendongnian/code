    interface IStudent
	{
		string studentID { get; }
		
		// other common properties below
	}
	public class StudentClass1 : IStudent
	{
		public string studentID { get; set; }
		public string studentFirstName { get; set; }
		public string studentLastName { get; set; }
	}
	public class StudentClass2 : IStudent
	{
		public string studentID { get; set; }
		public string studentGradePoint { get; set; }
	}

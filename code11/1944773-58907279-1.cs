	public partial class CourseAndnfo
	{
	   public Dictionary<string, CourseList> CourseList { get; set; }
		public PersonalInfo PersonalInfo { get; set; }
	}
	public partial class CourseList
	{
		public string a1_courseName { get; set; }
		public string a2_courseCode { get; set; }
	}
	public partial class PersonalInfo
	{
		public string Email { get; set; }
		public string TeacherInstitute { get; set; }
		public string TeacherName { get; set; }
	}

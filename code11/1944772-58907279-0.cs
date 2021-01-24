	public partial class CourseAndInfo
	{
		[JsonProperty("CourseList")]
		public Dictionary<string, CourseList> CourseList { get; set; }
		[JsonProperty("PersonalInfo")]
		public PersonalInfo PersonalInfo { get; set; }
	}
	public partial class CourseList
	{
		[JsonProperty("a1_courseName")]
		public string A1CourseName { get; set; }
		[JsonProperty("a2_courseCode")]
		public string A2CourseCode { get; set; }
	}
	public partial class PersonalInfo
	{
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("teacherInstitute")]
		public string TeacherInstitute { get; set; }
		[JsonProperty("teacherName")]
		public string TeacherName { get; set; }
	}

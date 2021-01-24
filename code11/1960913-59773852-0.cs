public class StudentDTO
{
	public string Name { get; set; }
	public DateTime Birthday { get; set; }
	
	public long RegistrationNumber { get; set; }
	public IEnumerable<GradeDTO> Grades { get; set; }
}
public class GradeDTO
{
	public int Value { get; set; }
	public virtual StudentDTO Student { get; set; }
	public virtual SubjectDTO Subject { get; set; }
}
public class SubjectDTO
{
	public string Name { get; set; }
	public virtual IEnumerable<GradeDTO> Grades { get; set; }
}
And then:
var res = from student in context.Student
		  select new StudentDTO
		  {
			  Name = student.Name,
			  Birthday = student.Birthday,
			  RegistrationNumber = student.RegistrationNumber,
			  Grades = from grade in student.Grades
					   select new GradeDTO
					   {
						   Value = grade.Value,
						   Subject = new SubjectDTO
						   {
							   Name = grade.Subject.Name
						   }
					   }
		  };

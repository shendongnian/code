    public class Grades
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	[ForeignKey("UpGradeId")]
    	public Grades UpGrade { get; set; }
    	public int UpGradeId { get; set; }
    }

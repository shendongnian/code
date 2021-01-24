public class Student
{
    public string StudentsUserId { get; set; }
    public bool is_accepted { get; set; }
    public int Number_preferences { get; set; }
    public List<Preference> Preferences { get; set; }
    public List<Offers> Offers { get; set; }
    public List<List> List { get; set; }
    [NotMapped]
    public IList<Courscategory> courshistory { get; set; }
}
and in your List class it should look like this:
public class List
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string StudentsUserId { get; set; }
        public string SupervisorUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Offers Offer { get; set; }
        public Student Student { get; set; }
        public List<Supervisors> Supervisor { get; set; }
        public List<Preference> Preference { get; set; }
    }
The generated extra field "ListCourseId" feels like just an automatically generated field by EF following the pattern [Table]+[PKey].

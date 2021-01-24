csharp
public class Program
{
    public static void Main(string[] args)
    {
        var studentInfos = FetchStudentInfo();
        using (var csv = new CsvWriter(Console.Out))
        {
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.RegisterClassMap<StudentInfoMap>();
            csv.WriteRecords(studentInfos);
        }
        Console.ReadKey();
    }
    public static List<StudentInfo> FetchStudentInfo()
    {
        Course[] courses1 = { new Course { CourseId = "1", CourseName = "java" }, new Course { CourseId = "2", CourseName = "c#" }, new Course { CourseId = "3", CourseName = "python" } };
        Course[] courses2 = { new Course { CourseId = "1", CourseName = "java" }, new Course { CourseId = "2", CourseName = "c#" } };
        return new List<StudentInfo>
        {
            new StudentInfo{ Student = new Student{Id = "12", Name = "Jim"}, Courses = courses1 },
            new StudentInfo{ Student = new Student{Id = "45", Name = "Dave"}, Courses = courses2 }
        };
    }
}
public class StudentInfoMap : ClassMap<StudentInfo>
{
    public StudentInfoMap()
    {
        References<StudentMap>(m => m.Student);
        Map(m => m.CourseNames).Index(3);
    }
}
public class StudentMap : ClassMap<Student>
{
    public StudentMap()
    {
        Map(m => m.Id);
        Map(m => m.Name);
    }
}
public class StudentInfo
{
    public Student Student { get; set; }
    public Course[] Courses { get; set; }
    public string[] CourseNames { get { return Courses.Select(c => c.CourseName).ToArray(); } }
}
public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
}
public class Course
{
    public string CourseId { get; set; }
    public string CourseName { get; set; }
}

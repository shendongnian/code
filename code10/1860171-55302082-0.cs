csharp
public class Result
{
    public string Subject { get; set; }
    public decimal? Marks { get; set; }
    public override string ToString()
    {
        return $"{Subject} = {Marks}";
    }
}
Make a slight change to your StudentResultExportMap.  You can set the 2nd number on `.Index(2, 7)` to handle the max number of grades you think a student might have.
csharp
public sealed class StudentResultExportMap : ClassMap<Student>
{
    public StudentResultExportMap()
    {
        AutoMap();
        Map(m => m.Grades).Name("Grade").Index(2, 7);
    }
}
You will then get `Id, Name, Grade1, Grade2, Grade3, Grade4, Grade5, Grade6` with the `toString()` value of `Result` for each grade.
csharp
var records = new List<Student>
{
    new Student{ Id = "1", Name = "First", Grades =  new [] {
        new Result { Subject = "Subject1", Marks = (decimal)2.5 } ,
        new Result { Subject = "Subject2", Marks = (decimal)3.5 } }},
    new Student{ Id = "2", Name = "Second", Grades =  new [] {
        new Result { Subject = "Subject1", Marks = (decimal)3.5 } ,
        new Result { Subject = "Subject2", Marks = (decimal)4.0 } }}
};
using (var writer = new StreamWriter("path\\to\\StudentResults.csv"))
using (var csv = new CsvWriter(writer))
{
    csv.Configuration.RegisterClassMap<StudentResultExportMap>();
    csv.WriteRecords(records);
}

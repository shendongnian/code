public class TopStudents {
  [NotMapped] // not persisted in database.
  public string AliasOrNameMajor => Alias ?? NameMajor;
}
and then do it this way:
foreach (var St in TopStudents)
{
   St.StudentsName = 
       Students.FirstOrDefault(e => e.Code == St.StudentCode)?.AliasOrNameMajor;
}

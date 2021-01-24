public class DbContext : DbContext
{
        public DbContext(): base("name=DbContext")
        {
        }
        public DbSet<Student> MyStudents { get; set; }
        public DbSet<StudentsSport> StudentsSports { get; set; }
        public DbSet<Sport> MySports { get; set; }
}
public class Student
{
    public int ID { get; set; }
    public List<StudentsSport> Actions { get; set; }
    public string Name { get; set; }
}
public class Sport
{
    public int ID { get; set; }
    public string SportName { get; set; }
}
public class StudentsSport
{
    public int ID { get; set; }
    [ForeignKey(Student)]
    public int StudentID { get; set; }
     
    [ForeignKey(Sport)]
    public int SportID { get; set; }
}
Then you can just do
var listOfActions = MyStudents.Select(s => s.Actions.Select(a => a.SportID));
var intersection = listOfActions 
    .Skip(1)
    .Aggregate(
        new HashSet<T>(listOfActions.First()),
        (h, e) => { h.IntersectWith(e); return h; }
    );
**EDIT:**
If you have students without sports then you will always get empty intersection list. If you don't want that then you will have to filter them 
var listOfActions = MyStudents.Select(s => s.Actions.Select(a => a.SportID)).Where(c => c.Any());

public class Toto
{
    public int ProjectID { get; set; }
    public string ProjectTime { get; set; }
}
static void Main(string[] args)
{
    var tmpList = new[]{
        new Toto{ProjectID=1,  ProjectTime="00:10" },
        new Toto{ProjectID=2,  ProjectTime="23:20" },
        new Toto{ProjectID=2,  ProjectTime="23:30" },
        new Toto{ProjectID=1,  ProjectTime="00:40" },
    };
var overviewList = tmpList.GroupBy(x => x.ProjectID)
            .Select(x => new
            {
                ProjectID = x.Key,
                ProjectTime = new TimeSpan(x.Sum(o => TimeSpan.Parse(o.ProjectTime).Ticks))
            });
Result:
 >   ProjectID =1, ProjectTime=00:50:00  
 ProjectID =2, ProjectTime=1.22:50:00
If you need to get the same string format again. You can use, but keep the format TimeSpan as long as you use it use that only for display.
     (int)X.ProjectTime.TotalHours +":" +X.ProjectTime.Minutes
 > ProjectID =1, ProjectTime=0:50  
 ProjectID =2, ProjectTime=46:50

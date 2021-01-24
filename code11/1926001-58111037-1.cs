public class Toto
{
    public int ProjectID { get; set; }
    public string ProjectTime { get; set; }
}
static void Main(string[] args)
{
    var tmpList = new[]{
        new Toto{ProjectID=1,  ProjectTime="00:10" },
        new Toto{ProjectID=2,  ProjectTime="00:20" },
        new Toto{ProjectID=2,  ProjectTime="00:30" },
        new Toto{ProjectID=1,  ProjectTime="00:40" },
    };
var overviewList = tmpList.GroupBy(x => x.ProjectID)
            .Select(x => new
            {
                ProjectID = x.Key,
                ProjectTime = new TimeSpan(x.Sum(o => TimeSpan.Parse(o.ProjectTime).Ticks))
            });
Result:
 >  ProjectID =1, ProjectTime=00:50:00   
 ProjectID =2, ProjectTime=00:50:00
If you need to get the same string format again. You can use :
     

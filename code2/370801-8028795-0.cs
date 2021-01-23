    void Main()
    {
    	string projects = "p1,p2,p3";
    	List<string> projectArray = projects.Split(',').ToList();
    
    	TestEntities db = new TestEntities();
    	db.wbs_projects = new List<TestEntities>();
    	db.wbs_projects.Add(new TestEntities(){prjName = "p1",prjID="Test1"});
    	db.wbs_projects.Add(new TestEntities(){prjName = "p2",prjID="Test2"});
    	db.wbs_projects.Add(new TestEntities(){prjName = "p3",prjID="Test3"});
    
    	var projectList = db.wbs_projects
    	  .Where(x => projectArray.Contains(x.prjName))
    	  .Select(x => x.prjID).ToList();
    
    	foreach(var item in projectList)
    	{
    		Console.WriteLine(item);//Test1,Test2,Test3
    	}
    		
    }
    
    public class TestEntities
    {	
    	public List<TestEntities> wbs_projects{get;set;}
    	
    	public string prjName{get;set;}
    	public string prjID{get;set;}
    }

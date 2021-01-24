    public class User
    {
    	public User()
    	{
    		this.Projects = new HashSet<Project>();
    	}
    	[Key]
    	public int Id { get; set; }
    	public string name { get; set; }
    	public string emailId { get; set; }
    	public virtual ICollection<Project> Projects { get; set;}
    }
    
    public class Project
    {	
    	public Project()
    	{
    		this.TimeSheetData = new HashSet<TimeSheetData>();
    	}
    	[Key]
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int userId { get; set; }
    	[ForeignKey("userId")]
    	public virtual User User {get; set; }
    	public virtual ICollection<TimeSheetData> TimeSheetData { get; set;}
    }
    
    public class TimeSheetData
    {
    	[Key]
    	public int id { get; set; }
    	public int project_id { get; set; }
    	[ForeignKey("project_id")]
    	public virtual Project Project {get; set; }
    	public string hours_logged { get; set; }
    }

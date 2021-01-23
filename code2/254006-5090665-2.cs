    void Main()
    {
    	var projects = new List<Project>();
    	projects.Add(new Project { Name = "Project1", Tags = new int[] { 2, 5, 3, 1 } });
    	projects.Add(new Project { Name = "Project2", Tags = new int[] { 1, 4, 7 } });
    	projects.Add(new Project { Name = "Project3", Tags = new int[] { 1, 7, 12, 3 } });
    	
    	var filteredTags = new int []{ 1, 3 };
    	var filteredProjects = projects.Where(p => p.Tags.Intersect(filteredTags).Count() == filteredTags.Length);	
    }
    
    
    class Project {
    	public string Name;
    	public int[] Tags;
    }

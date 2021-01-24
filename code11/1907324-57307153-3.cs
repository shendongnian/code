    public class Project
        {
            public int ProjectID { get; set; }
            public string ProjectName{ get; set; }
            public string ProjectLocation{ get; set; }
      
        }
    public class People
        {
            public int Id{ get; set; }
            public string Name{ get; set; }
        
        }
    public class ProjectVm 
    {
    
            public int ProjectID { get; set; }
            public string ProjectName{ get; set; }
            public string ProjectLocation{ get; set; }
            public  ICollection<People> ListOfPeople { get; set; }
    }
 
   

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
    Public class ProjectVm 
    {
    
            public int ProjectID { get; set; }
            public string ProjectName{ get; set; }
            public string ProjectLocation{ get; set; }
            public  ICollection ListOfPeople { get; set; }
    }
 
   

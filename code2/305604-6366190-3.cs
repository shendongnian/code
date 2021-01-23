     public class ProjectDetailManager 
     {   
       public static List<ViewProjectDetail> GetProjectDetailById(int id)    
       {
           using(var dbContext = new SDMPREntities())
           {
              return dbContext.ViewProjectDetails(id).ToList();
           }    
        }
     
        public static ProjectProgress GetProjectProgress(int id)    
        {
           using(var dbContext = new SDMPREntities())
           {
              return dbContext.ProjectProgress().Where(x=>x.ProjectId ==id).FirstOrDefault();
           }    
        }
     
     }

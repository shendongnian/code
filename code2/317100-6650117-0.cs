    public class Repository : IRepository
    {
    
     private Datacontext context;
    
     public Repository()
     {
         context = new Datacontext();
     }
    
     public IQueryable<Entity> GetEntities()
     {
         return from e in context.Entity select e;
     }  
    
     public int Save()
     {
         // Return the number of the affected rows to determine in your code whether your query executed or not 
         return context.SubmitChanges();
     }
    }

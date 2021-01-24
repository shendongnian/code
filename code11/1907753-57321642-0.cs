    public sealed class CacheManagementHelper : IDisposable 
    {
       private readonly GJobEntities db = new GJobEntities();
    
       public List<User> GetUsers()
       { 
           return db.Users.ToList();
       }
    
       public void Dispose()
       { 
           db.Dispose();          
       }
    }

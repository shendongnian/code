    public class MasterDal : DbContext
        {
            public MasterDal(string nameOrConnectionString) : base(nameOrConnectionString)
            {
    
            }
           // DbSet &  OnModelCreating etc 
        }

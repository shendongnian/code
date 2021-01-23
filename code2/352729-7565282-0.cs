    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions.Edm.Db;
    
    public class MyDbContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    using System.Data.Entity.ModelConfiguration.Conventions.Edm.Db;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {    
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }

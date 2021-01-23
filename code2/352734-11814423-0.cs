    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    
    namespace YourNamespace
    {
        public class DataContext : DbContext
        {
            protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
            {
                dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
    
            public DbSet<User> User { get; set; }
        }
    }

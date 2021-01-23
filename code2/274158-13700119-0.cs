     protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {                
                modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
                modelBuilder.Entity<MyEntity>()
                   .Map(m =>
                   {
                       **m.MapInheritedProperties();**                   
                   });
            }

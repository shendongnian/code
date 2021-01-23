    In DbContext class overide `OnModelCreating` and configure property `Start` (for  explanation reasons it's a property of EntityClass class).
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure only one property 
            modelBuilder.Entity<EntityClass>()
                .Property(e => e.Start)
                .HasColumnType("datetime2");
           //or configure all DateTime Preperties globally(EF 6 and Above)
            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }

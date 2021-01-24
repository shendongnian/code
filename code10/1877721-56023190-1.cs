    class MyContext : DbContext
    {
        public DbSet<SomeClass> sample{ get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("sampleNumber", schema: "shared")
                .StartsAt(10001)
                .IncrementsBy(1);  
            modelBuilder.Entity<SomeClass>()
            .Property(o => o.SomeClassId)
            .HasDefaultValueSql("NEXT VALUE FOR shared.sampleNumber");
        }
        }

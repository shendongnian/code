    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
           modelBuilder
                .Entity<Machine>()
                .Property(e => e.Delay)
                .HasConversion(new TimeConverter());
            modelBuilder
               .Entity<Machine>()
               .Property(e => e.Runtime)
               .HasConversion(new TimeConverter());
    }

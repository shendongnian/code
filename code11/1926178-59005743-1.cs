     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         modelBuilder
             .Entity<Box>()
             .Property(e => e.Volume)
             .UsePropertyAccessMode(PropertyAccessMode.Property);
     }

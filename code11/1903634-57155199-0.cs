     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
         modelBuilder.Entity<TimeEntry>().Property(e => e.TimeWorked).HasPrecision(4, 2);
         base.OnModelCreating(modelBuilder);
     }

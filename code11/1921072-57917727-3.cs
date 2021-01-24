    class YourContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasKey(c => new { c.Driver, c.RacingVehicle });
        }
        // ...
    }

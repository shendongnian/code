    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>()
                    .HasOptional(j => j.OwnedBy)
                    .WithMany()
                    .IsIndependent()
                    .Map(m => m.MapKey(u => u.Username, "TheFKNameInYourDB"));
    }

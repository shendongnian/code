    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Rider>()
            .Property(e => e.Mount)
            .HasConversion(
                v => v.ToString(),
                v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));
    }

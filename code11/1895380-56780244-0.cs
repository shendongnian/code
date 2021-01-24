    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var converter = new ValueConverter<EquineBeast, string>(
            v => v.ToString(),
            v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));
    
        modelBuilder
            .Entity<Rider>()
            .Property(e => e.Mount)
            .HasConversion(converter);
        modelBuilder
            .Entity<Rider>()
            .Property(e => e.SecondaryMount)
            .HasConversion(converter);
            
    }

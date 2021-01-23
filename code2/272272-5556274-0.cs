    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beta>()
            .HasKey(b => new { b.Id, b.SequenceNumber });
        modelBuilder.Entity<Alpha>()
            .HasMany(a => a.Beta)
            .WithMany();
    }

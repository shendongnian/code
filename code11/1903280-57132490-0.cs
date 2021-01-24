    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("getdate()");
    }

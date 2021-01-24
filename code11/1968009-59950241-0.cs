    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyEntity>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAddOrUpdate();
        });
        base.OnModelCreating(modelBuilder);
    }

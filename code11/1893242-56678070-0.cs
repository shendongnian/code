    protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
              modelBuilder.Entity<Item>()
                   .Property(b => b.CreatedDateUtc)
                   .HasDefaultValueSql("GETUTCDATE()");
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUser>()
          .HasMany(c => c.EditedArticles)
          .WithOne(e => e.EditedBy);
        modelBuilder.Entity<AdminUser>()
        .HasMany(c => c.CreatedArticles)
        .WithOne(e => e.CreatedBy);
        modelBuilder.Entity<AdminUser>()
        .HasMany(c => c.PublishedArticles)
        .WithOne(e => e.PublishedBy);
    }

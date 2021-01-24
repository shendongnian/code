    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUserCategory>(
        build =>
        {
            build.HasKey(t => new { t.ApplicationUserID, t.CategoryID });
        });
        builder.Entity<ApplicationUserCategory>()
            .HasOne(pc => pc.ApplicationUser)
            .WithMany(p => p.ApplicationUserCategories)
            .HasForeignKey(pc => pc.ApplicationUserID);
        builder.Entity<ApplicationUserCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ApplicationUserCategories)
            .HasForeignKey(pc => pc.CategoryID);
    }

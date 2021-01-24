    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ContactCategory>()
        .HasOne(x => x.Category)
        .WithMany(x => x.ContactCategories)
        .HasForeignKey(x => x.CategoryId);
      modelBuilder.Entity<ContactCategory>()
        .HasOne(x => x.Contact)
        .WithMany(x => x.ContactCategories)
        .HasForeignKey(x => x.ContactId);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne<Author>()
            .WithMany(a => a.Books)
            .HasForeignKey("AuthorId")
            .OnDelete(DeleteBehavior.SetNull);
        base.OnModelCreating(modelBuilder);
    }

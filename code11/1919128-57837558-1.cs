    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Book>()
                    .HasMany<Author>(s => s.Authors)
                    .WithMany(c => c.Books)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("BookID");
                                cs.MapRightKey("AuthorID");
                                cs.ToTable("AuthorBook");
                            });
    
    }

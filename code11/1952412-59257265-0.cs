    protected override void OnModelCreating(ModelBuilder builder)
             {
                builder.Entity<Article>(b =>
                {
                    b.HasOne(c => c.Content)
                   .WithOne(a => a.Article)
                   .HasForeignKey<Content>(d => d.ArticleID);
                });
             }
    

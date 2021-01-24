    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .HasOne(p => p.FrontPageItem)
            .WithOne(i => i.Article)
            .HasForeignKey<Article>(b => b.FrontPageItemId); // <-- Here it is
        modelBuilder.Entity<WebPage>()
            .HasOne(p => p.FrontPageItem)
            .WithOne(i => i.WebPage)
            .HasForeignKey<WebPage>(b => b.FrontPageItemId); // <--Here it is
    }

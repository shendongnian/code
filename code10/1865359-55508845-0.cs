    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne(a => a.CreatedBy).WithMany(au => au.CreatedArticles);
            builder.HasOne(a => a.EditedBy).WithMany(au => au.EditedArticles);
            builder.HasOne(a => a.PublishedBy).WithMany(au => au.PublishedArticles);
        }
    }

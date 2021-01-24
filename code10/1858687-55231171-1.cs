    using DL.SO.EFCore.Learning.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    namespace DL.SO.EFCore.Learning.Data.Configurations
    {
        public class ArticleConfiguration : IEntityTypeConfiguration<Article>
        {
            public void Configure(EntityTypeBuilder<Article> builder)
            {
                builder.HasKey(x => x.Id);
    
                builder.ToTable(nameof(Article));
            }
        }
    }

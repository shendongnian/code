    using DL.SO.EFCore.Learning.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    namespace DL.SO.EFCore.Learning.Data.Configurations
    {
        public class ArticleQualityCheckDefinitionConfiguration : IEntityTypeConfiguration<ArticleQualityCheckDefinition>
        {
            public void Configure(EntityTypeBuilder<ArticleQualityCheckDefinition> builder)
            {
                builder.HasKey(x => new { x.ArticleId, x.QualityCheckDefinitionId });
    
                builder.HasOne(x => x.Article)
                    .WithMany(x => x.ArticleQualityCheckDefinitions)
                    .HasForeignKey(x => x.ArticleId);
    
                builder.HasOne(x => x.QualityCheckDefinition)
                    .WithMany(x => x.ArticleQualityCheckDefinitions)
                    .HasForeignKey(x => x.QualityCheckDefinitionId);
    
                builder.ToTable(nameof(ArticleQualityCheckDefinition));
            }
        }
    }

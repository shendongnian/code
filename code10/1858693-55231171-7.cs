    using DL.SO.EFCore.Learning.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    namespace DL.SO.EFCore.Learning.Data.Configurations
    {
        public class QualityCheckDefinitionConfiguration : IEntityTypeConfiguration<QualityCheckDefinition>
        {
            public void Configure(EntityTypeBuilder<QualityCheckDefinition> builder)
            {
                builder.HasKey(x => x.Id);
    
                builder.ToTable(nameof(QualityCheckDefinition));
            }
        }
    }

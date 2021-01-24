    using DL.SO.EFCore.Learning.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    namespace DL.SO.EFCore.Learning.Data.Configurations
    {
        public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
        {
            public void Configure(EntityTypeBuilder<StockItem> builder)
            {
                builder.HasKey(x => x.Id);
    
                builder.ToTable(nameof(StockItem));
            }
        }
    }

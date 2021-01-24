    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.RegionId); //Primary Key
            builder.ToTable("TableName", "dbo");
        }
    }

    class PriorityOverrideConfiguration : IEntityTypeConfiguration<PriorityOverride>
    {
        public void Configure(EntityTypeBuilder<PriorityOverride> builder)
        {
            builder.ToTable("PriorityOverrides");
            ...
        }
    }

    public void Configure(EntityTypeBuilder<DimActors> entity)
    {
        foreach (var pb in entity.Metadata.GetProperties()
            .Where(p => p.ClrType == typeof(string))
            .Select(p =>
                new
                {
                    PropertyBuilder = entity.Property(p.Name),
                    Property = p
                }))
        {
            int length = pb.Property.GetMaxLength() ?? 256;
            pb.PropertyBuilder.HasColumnType($"NCHAR({length})");
        }
    }

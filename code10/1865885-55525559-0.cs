C#
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType(VARCHAR)
            .HasMaxLength(150);
        builder.Property(x => x.Initials)
            .HasColumnType(VARCHAR)
            .HasMaxLength(5);
        builder.Property(x => x.Code)
            .HasColumnType(VARCHAR)
            .HasMaxLength(5);
        // Remove this
        //builder.Property(x => x.State)
        //    .HasColumnType(UNIQUEIDENTIFIER)
        //    .IsRequired();
        // Add this
        builder
            .HasOne(y => y.State)
            .WithMany();
    }

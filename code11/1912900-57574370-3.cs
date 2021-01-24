    entity.Property(e => e.Status)
        .HasColumnName("Status")
        .HasMaxLength(255)
        .IsUnicode(false)
        .HasConversion(
            v => v.ToString(),
            v => v.ConvertToEnum<Status>());

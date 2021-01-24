    public void Configure(EntityTypeBuilder<MachineHelpRequests> builder)
            {
                //... model builder code above
                builder.Property(e => e.IsAcknowledged)
                    .HasColumnName("acknowledged_mhr")
                    .HasColumnType("varchar(45)")
                    .HasConversion(EntityFrameworkCoreValueConverters.dbVarCharNullableToBoolNullableConverter);
                //... model builder code below
    }

    public override void Configure(EntityTypeBuilder<NewEntity> builder) {
     	builder.ToTable("Entities");
     	builder.Property(m => m.Prop1).HasColumnName("Prop1");
     	builder.Property(m => m.Prop2).HasColumnName("Prop2");
     	builder.Property(m => m.Type_Id).HasColumnName("Type_Id");
        builder.HasOne<BaseEntity>().WithOne().HasForeignKey<NewEntity>(e => e.Id);
    }

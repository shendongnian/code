    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Properties()
           .Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name.ToUpperInvariant()));
        modelBuilder.Types()
           .Configure(c => c.ToTable(c.ClrType.Name.ToUpperInvariant()));            
    }

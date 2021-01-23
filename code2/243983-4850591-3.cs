    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.Edm.Db.ColumnTypeCasingConvention>();
        modelBuilder.Conventions.Add(new DefaultSchemaConvention("TEST"));
    }  

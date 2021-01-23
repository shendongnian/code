    public static readonly string DefaultSchemaName = "Entities";
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchemaName);
        ...

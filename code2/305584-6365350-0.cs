    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YourEntityName>().MapSingleType(t => new {
            columnId = t.Id,
            description = t.ProductName // If database column name is description and your entity property name is ProductName
            product_name = t.Description // If it's the other way around...
        }).ToTable("DatabaseTableName");
    }

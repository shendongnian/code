    protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
            {
                base.OnModelCreating(dbModelBuilder);
                dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                dbModelBuilder.Entity<TableName>().ToTable("TableName", schemaName: "EDI");
            }

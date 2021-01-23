    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        MapEntity<Variable>(modelBuilder, toTable: "Variables");
        MapEntity<Variable2>(modelBuilder, toTable: "Variables");
        foreach (var entityType in ModelExtensions.SelectMany(modelExtension => modelExtension.IntroduceModelEntities()))
        {
            MapEntity(modelBuilder, entityType, toTable: "Variables");
        }
    }

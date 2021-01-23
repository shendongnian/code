    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Conventions
                    .Remove<System.Data.Entity.Database.IncludeMetadataConvention>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Country>(entity => {
            entity.ToTable("CountriesCustomTableName");
        });
    }

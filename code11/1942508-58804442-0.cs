    private void MapLookupEntitity<TLookup>(DbModelBuilder modelBuilder) where TLookup : BaseLookupEntity
    {
        // unique 
        modelBuilder.Entity<TLookup>()
            .HasIndex(c => c.Enum)
            .IsUnique();
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        MapLookupEntitity<UserType>(modelBuilder);
        MapLookupEntitity<AnotherType>(modelBuilder);
        // map some more..
    }

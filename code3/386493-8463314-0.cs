    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>.HasMany(p => p.Addresses).WithOptional()
            .Map(d => d.MapKey("EmployeeId"));
        modelBuilder.Entity<Supplier>.HasMany(p => p.Addresses).WithOptional()
            .Map(d => d.MapKey("SupplierId"));
        modelBuilder.Entity<Customer>.HasMany(p => p.Addresses).WithOptional()
            .Map(d => d.MapKey("CustomerId"));
    }

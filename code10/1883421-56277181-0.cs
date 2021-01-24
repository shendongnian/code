    public CustomDbContext CreateDbContext()
    {
         var options = new DbContextOptionsBuilder<CustomDbContext>()
             .UseSqlServer(_connectionString)
             .Options;
         return new CustomDbContext(options);
    }

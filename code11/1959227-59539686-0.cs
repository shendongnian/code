    Type dbContextType = typeof(MyDbContext);
    Type dbContextOptionsBuilderType = typeof(DbContextOptionsBuilder<>);
    Type dbContextOptionsBuilderGenericType = dbContextOptionsBuilderType.MakeGenericType(dbContextType);
    DbContextOptionsBuilder dbContextOptionsBuilderInstance = Activator.CreateInstance(dbContextOptionsBuilderGenericType) as DbContextOptionsBuilder;
    DbContextOptions dbContextOptions = dbContextOptionsBuilderInstance.UseInMemoryDatabase(databaseName: "Test").Options;

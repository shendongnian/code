    Type dbContextType = typeof(MyDbContext);
    // 1st get type of Generic object
    Type dbContextOptionsBuilderType = typeof(DbContextOptionsBuilder<>);
    // 2nd call "MakeGenericType" method by passing the "T" type
    Type dbContextOptionsBuilderGenericType = dbContextOptionsBuilderType.MakeGenericType(dbContextType);
    // 3rd create an instance by using "Activator.CreateInstance"
    DbContextOptionsBuilder dbContextOptionsBuilderInstance = Activator.CreateInstance(dbContextOptionsBuilderGenericType) as DbContextOptionsBuilder;
    DbContextOptions dbContextOptions = dbContextOptionsBuilderInstance.UseInMemoryDatabase(databaseName: "Test").Options;

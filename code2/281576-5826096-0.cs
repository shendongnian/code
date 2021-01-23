    // Get "Data Source=SomeServer..."
    var innerConnectionString = GetInnerConnectionStringFromMachinConfig();
    // Build the Entity Framework connection string.
    var connectionString = CreateEntityConnectionString("Entity", innerConnectionString);
    var context = new EntityContext(connectionString);

    const string OriginalConnectionString = "..."; // (Copy out of app.config)
    var connectionString = RedirectedEntityFrameworkConnectionString(OriginalConnectionString, myFileName, null);
    using (var context = new MyEntities(connectionString))
    {
        ...
    }

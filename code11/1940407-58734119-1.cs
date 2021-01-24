    //
    // Summary:
    //     Constructs a new context instance using the given string as the name or connection
    //     string for the database to which a connection will be made. See the class remarks
    //     for how this is used to create a connection.
    //
    // Parameters:
    //   nameOrConnectionString:
    //     Either the database name or a connection string.
    [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
    public DbContext(string nameOrConnectionString);

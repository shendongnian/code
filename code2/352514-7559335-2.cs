    public static Database ChangeDatabase(this Database db, string databaseName)
    {
        // Change Database
        DbConnectionStringBuilder builder = new DbConnectionStringBuilder()
        {
            ConnectionString = db.ConnectionString
        };
        builder["database"] = databaseName;
        // Create new EL DB using new connection string
        return new GenericDatabase(builder.ConnectionString, 
            db.DbProviderFactory);
    }
...
    // Get Original EL DB
    Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("MYDB");
    object result = db.ExecuteScalar(System.Data.CommandType.Text, 
        "select top 1 name from sysobjects");
            
    Console.WriteLine(result);
    db = db.ChangeDatabase("AnotherDB");
    result = db.ExecuteScalar(CommandType.Text,
        "select top 1 RoleName from Roles");
            
    Console.WriteLine(result);

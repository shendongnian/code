    // Get Original EL DB
    Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("MYDB");
    object result = db.ExecuteScalar(System.Data.CommandType.Text, 
        "select top 1 name from sysobjects");
            
    Console.WriteLine(result);
    
    // Change Database
    DbConnectionStringBuilder builder = new DbConnectionStringBuilder()
    {
        ConnectionString = db.ConnectionString
    };
    
    builder["database"] = "AnotherDB";
    
    // Create new EL DB using new connection string
    db = new GenericDatabase(builder.ConnectionString, db.DbProviderFactory);
    result = db.ExecuteScalar(CommandType.Text, 
        "select top 1 RoleName from Roles");
    Console.WriteLine(result);

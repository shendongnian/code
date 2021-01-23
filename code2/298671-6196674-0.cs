    string connStr = "Data Source = FooDatabase.sdf; Password = SomePassword";
    if (File.Exists("FooDatabase.sdf")) 
        File.Delete("FooDatabase.sdf");  
    SqlCeEngine engine = new SqlCeEngine(connStr); 
    engine.CreateDatabase();
    SqlCeConnection conn = null;
    try 
    {
        conn = new SqlCeConnection(connStr);
        conn.Open();
        SqlCeCommand cmd = conn.CreateCommand();
        cmd.CommandText = "CREATE TABLE FooTable(col1 int, col2 ntext)";
        cmd.ExecuteNonQuery();
    }
    catch 
    {
    
    }
    finally 
    {
        conn.Close();
    }

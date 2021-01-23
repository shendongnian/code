    // Get Original EL DB
    Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>("MYDB");
    object result = db.ExecuteScalar(CommandType.Text, 
        "select top 1 name from sysobjects");
    Console.WriteLine(result);
                
    // Change DB with ADO.NET
    using (IDbConnection conn = db.CreateConnection())
    {
        conn.Open();
        conn.ChangeDatabase("AnotherDB");
    
        using (IDbCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select top 1 RoleName from Roles";
            cmd.CommandType = CommandType.Text;
    
            result = cmd.ExecuteScalar();
        }
    }
    
    Console.WriteLine(result);

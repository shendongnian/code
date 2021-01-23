    using( var conn = new OleDbConnection (connectionstring) )
    {
        conn.Open();
    
        using( cmd = conn.CreateCommand() )
        {
             for( ... )
             {
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.Parameters.Add (...);
                cmd.ExecuteNonQuery();
             }
        }
    }

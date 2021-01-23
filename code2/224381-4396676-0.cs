    using( var conn = new OleDbConnection (connectionstring) )
    {
        conn.Open();
    
        using( cmd = new OleDbCommand (conn) )
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

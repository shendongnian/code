    using( var conn = new OleDbConnection (connectionstring) )
    {
        conn.Open();
    
        using( cmd = conn.CreateCommand() )
        {
             cmd.Parameters.Add (..);
             ...
             for( ... )
             {
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.Parameters["@p_param"].Value = ...
                cmd.ExecuteNonQuery();
             }
        }
    }

    using ( var oConn = new SqliteConnection ( "Data Source=" + DB_NAME ) )
    {
        oConn.Open (  );
    
        // Wrap the whole bulk insertion into one block to make it faster, otherwise one transaction per INSERT would be created.
        // Note that this is differen from "BEGIN TRANSACTION" which would increase memory usage a lot!
        SqliteCommand oCmd = new SqliteCommand ( "BEGIN", oConn );
        oCmd.ExecuteNonQuery (  );
        oCmd.Dispose (  );
    
        oCmd = new SqliteCommand ( "INSERT INTO LocalObjects ( intID, intParentID, intObjectType, strName, dtModified VALUES (@intID, @intParentID, @intObjectType, @strName, @dtModified)", oConn );
        
        // <do this for all of your parameters>.
        var id = oCmd.CreateParameter();
        id.ParameterName = "@intID";
        oCmd.Parameters.Add(id);
        // </do this for all of your parameters>.
    
        foreach ( MyObj oObj in aMyObjects )
        {
            // <do this for all of your parameters>.
            id.Value = oMyObj.ID;
            // </do this for all of your parameters>.
            
            oCmd.ExecuteNonQuery (  );
        }
    
        oCmd.Dispose();
    
        oCmd = new SqliteCommand ( "END", oConn );
        oCmd.ExecuteNonQuery (  );
        oCmd.Dispose (  );
    
        oConn.Close (  );
        oConn.Dispose (  );
    }

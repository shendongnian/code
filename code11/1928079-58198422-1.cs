    using (SqlConnection connection = new SqlConnection(sqlServerConnString))
    {
        connection.Open();
    
        //string addLogin = "CREATE LOGIN [@databaseUserId] WITH PASSWORD = '@databasePassword';";
        string addLogin = "DECLARE @SQL nvarchar(MAX) = N'CREATE LOGIN ' + QUOTENAME(@databaseUserId) + N' WITH PASSWORD = N' + QUOTENAME(@databasePassword,'''') + N';'; EXEC sp_executesql @SQL;";
        using (SqlCommand command = new SqlCommand(addLogin, connection))
        {
    
            command.Parameters.Add("databaseUserId", System.Data.SqlDbType.NVarChar,128).Value = databaseUserId;
            command.Parameters.Add("databasePassword", System.Data.SqlDbType.NVarChar,128).Value = databasePassword;
    
            command.ExecuteNonQuery();
        }
    }

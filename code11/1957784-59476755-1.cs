    using (var dbConn = new SqlConnection(_connectionStrings.SqlServer))
    {
        var mySqlText = @"
                           ....  some SQL code here
                         ";
    
        foreach(var widget in widgets)
        {
            await dbConn.ExecuteAsync(mySqlText, widget); 
        }
    }

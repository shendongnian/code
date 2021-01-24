     using (var dbConn = new SqlConnection(_connectionStrings.SqlServer))
    {
        var mySqlText = @"
                           ....  some SQL code here
                         ";
        var allTasks = widgets.Select(widget => dbConn.ExecuteAsync(mySqlText, widget));
    
        await Task.WhenAll(allTasks);
    }

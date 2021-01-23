    string sql = "Select * from customer where username in ('";
    
    foreach(string s in usernames)
    {
       sql += s + "','";
    }
    
    //Add some code to clean up the query (remove trailing  commas and such)
    
    return _dbConnection.ExecuteQuery(sql);

    string sql = "Select * from customer where username in (";
    
    string comma = "";
    foreach(string s in usernames)
    {
       sql += comma + "'" + CleanSqlParameter(s) + "'";
       comma = ", ";
    }
    
    return _dbConnection.ExecuteQuery(sql);

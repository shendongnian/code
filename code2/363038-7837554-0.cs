    var paramNames = new List<string>();
    var myCommand = new SqlCommand();
    foreach (string username in usernames){
      var paramName = "@user" + paramNames.Count;
      myCommand.Parameters.Add(paramName, SqlDbType.NVarChar);
      myCommand.Parameters[paramName].Value = username;
      paramNames.Add(paramName);
    }
    return _dbConnection.ExecuteQuery("Select * from customer where username in (" + string.Join(",", paramNames) + ")");

        var myCommand = new SqlCommand();
        int i = 0;
        string param = string.Empty;
        foreach (string username in usernames)
        {
            string paramName = string.Format("@username{0}", i);
            myCommand.Parameters.Add(paramName, SqlDbType.NVarChar);
            myCommand.Parameters[paramName].Value = username;
            param += string.Format("  (username={0}) or", paramName);
            i++;
        }
        param = param.Substring(0, param.Length - 2);
        return _dbConnection.ExecuteQuery("Select * from customer where " + param);

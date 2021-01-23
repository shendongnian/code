    public void ExecuteQuery(string sql, params object[] parameters)
    {
        //format the sql string with safe parameter names
        var paramNames = new string[parameters.Length];
        for (int i = 0; i<parameters.Length; i++)
        {
            paramNames[i] = "?";
        }
        sql = string.Format(sql, paramNames);
        using (OleDbConnection sqlConnect = drtevs.GetConnection())
        {   
            OleDbCommand command.CommandText = sql;
            foreach (int i = 0; i< parameters.Length; i++)
            {
                command.Parameters.Add(new OleDbParameter("?", parameters[i]));
            }
            command.ExecuteNonQuery();
            
        }
    }

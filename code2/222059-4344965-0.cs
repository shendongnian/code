    List<SqlParameter> parameters = new List<SqlParameter> { };
    
    string status = "dummystatus";
    string date = Datetime.Now;
    parameters.Add(new SqlParameter("@Status", status));
    parameters.Add(new SqlParameter("@date", date));
    
    SqlCommand cmd = new SqlCommand();
    command.Connection = connection;
    
    //set the command text (stored procedure name or SQL statement)
    command.CommandText = commandText;
    command.CommandType = commandType;
    foreach (SqlParameter p in parameters)
    {
        command.Parameters.Add(p);
    }
    SqlDataAdapter da = new SqlDataAdapter(command);
    DataSet ds = new DataSet();
    
    //fill the DataSet using default values for DataTable names, etc.
    da.Fill(ds);
    
    // detach the SqlParameters from the command object, so they can be used again.			
    cmd.Parameters.Clear();

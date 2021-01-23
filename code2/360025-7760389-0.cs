    using(SqlConnection myConnection = new SqlConnection(myconnectionString))
    { 
    SqlCommand myCommand = new SqlCommand(); 
    myCommand.CommandType = CommandType.StoredProcedure; 
    myCommand.CommandText = "usp_GetCustomer";     
    myCommand.Parameters.Add("@USER_NAME", SqlDbType.VarChar).Value = sUserName;//user name that you pass to SP     
    myCommand.Parameters.Add("@Month", SqlDbType.VarChar).Value = iMonth;//Month that you pass to SP     
    //To get Return value from StoreProcedure     
    myCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;     
    myConnection .Open();
    myCommand.ExecuteScalar();     
    //Returnvalue from SP     
    return Convert.ToInt32(command.Parameters["@ReturnValue"].Value); 
    }

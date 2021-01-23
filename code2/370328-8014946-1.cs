    SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
    SqlCommand SqlCommand = new SqlCommand();
    
    SqlConnection.Open();
    SqlCommand.CommandText = "select * from table";
    SqlCommand.Connection = SqlConnection;
    SqlDataReader dr = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
 

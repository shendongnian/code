    private void Asynchronous(IAsyncResult asyncResult)
    {
                    System.Data.SqlClient.SqlDataReader reader;
                    try
                    {
                        System.Data.SqlClient.SqlCommand command =
                           asyncResult.AsyncState as System.Data.SqlClient.SqlCommand;
                        reader = command.EndExecuteReader(asyncResult);
                        while (reader.Read())
                        {
                        }
                        reader.Close();
                    }
                    catch
                    {
                    }
    }
    public void GeneratePayrollAsync(string payProcessID)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection("ConnectionString"))
            {
                using (SqlCommand command = new SqlCommand("proc_GeneratePayroll", connection))
                {
                    command.CommandTimeout = 3600;
                    command.CommandType = CommandType.StoredProcedure;
                    //Set Your stored procedure parameter here
                    connection.Open();
                    command.BeginExecuteReader(Asynchronous, command, CommandBehavior.Default);
                }
            }
        }
        catch (Exception ex) {  }
    }

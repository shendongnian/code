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
                using (SqlCommand cmd = new SqlCommand("proc_GeneratePayroll", connection))
                {
                    cmd.CommandTimeout = 3600;
                    cmd.CommandType = CommandType.StoredProcedure;

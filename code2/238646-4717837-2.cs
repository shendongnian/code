    try
    {
        try
        {
            connection.Open();
            string storedProc = "GetData";
            SqlCommand command = new SqlCommand(storedProc, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
            return (byte[])command.ExecuteScalar();
        }
        finally
        {
            connection.Dispose();
        }
    }
    catch (Exception)
    {
    }

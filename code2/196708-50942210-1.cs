    using (var connection = new SqlConnection(ConnectionString))
    {
        connection.Open();
        SqlCommand command = new SqlCommand("pDoSomethingParamsRes", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@i", 1);
        var outParam = new SqlParameter("@out", SqlDbType.VarChar);
        outParam.Direction = ParameterDirection.Output;
        outParam.Size = 50; // this is example
        command.Parameters.Add(outParam);
        command.ExecuteNonQuery();
        Console.WriteLine(command.Parameters["@out"].Value.ToString());
    }

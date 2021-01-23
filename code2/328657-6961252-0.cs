    private static DataSet ReadData(string connectionString, string queryString)
    {
        DataSet dataSet;
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command =
                new SqlCommand(queryString, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);
        }
    
        return dataSet;
    }

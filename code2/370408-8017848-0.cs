    DataSet dataset = new DataSet();
    using (SqlConnection connection = 
        new SqlConnection(connectionString))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(
            "select * from alert", connection);
        adapter.Fill(dataset);
    }

    DataTable results = new DataTable();
    using(SqlConnection conn = new SqlConnection(connString))
    {
        using(SqlCommand command = new SqlCommand(query, conn))
        {
            conn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(results);
        }
    }

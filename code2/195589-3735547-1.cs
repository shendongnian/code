    DataTable results = new DataTable();
    using(SqlConnection conn = new SqlConnection(connString))
        using(SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
               dataAdapter.Fill(results);

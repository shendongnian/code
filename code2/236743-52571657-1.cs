    int count = 0;    
    using (new SqlConnection connection = new SqlConnection("connectionString"))
    {
        sqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM table_name", connection);
        connection.Open();
        count = (int32)cmd.ExecuteScalar();
    }

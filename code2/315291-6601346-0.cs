    using (SqlConnection connection = new SqlConnection("Data Source=raven\\sqlexpress;Initial Catalog=ucs;Integrated Security=True;Pooling=False"))
    {
        SqlCommand command = connection.CreateCommand();
    
        command.CommandText = "SELECT * from your_view WHERE your_where_clause";
    
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                // process result
                reader.GetInt32(0); // get first column from view, assume it's a 32-bit int
                reader.GetString(1); // get second column from view, assume it's a string
                // etc.
            }
        }
    }

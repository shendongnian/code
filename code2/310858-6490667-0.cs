    using (SqlConnection connection = new SqlConnection("..."))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "...";
    
        connection.Open();
    
        command.ExecuteNonQuery();
    }

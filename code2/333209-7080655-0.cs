    string insert = "INSERT INTO dokimastikospinakas (pliroforia) VALUES (@alpha)";
    
    using (SqlConnection connection = new SqlConnection(...))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(insert, connection))
        {
            command.Parameters.Add("@alpha", alpha);
            command.ExecuteNonQuery();
        }
    }

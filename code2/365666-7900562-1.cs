    using (SqlConnection con = new SqlConnection(...))
    {
        con.Open();
        using (SqlCommand command = ...)
        {
            // Execute the command
        }
    }

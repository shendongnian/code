    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    SqlCommand command = new SqlCommand(queryString, connection);
    command.Parameters.Add(new SqlParameter("AnnID", id));
    command.Parameters.Add(new SqlParameter("AnnTitle", title));
    ............
    ..............
    command.Connection.Open();
    command.ExecuteNonQuery();
    }

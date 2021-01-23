    string idValue = String.Empty
    string query = " Select id from table where name = 'Michael'";
    SqlConnection connection = new SqlConnection(connectionString);
    SqlCommand command = new SqlCommand(query, connection);
    SqlDataReader reader;
    connection.Open();
    reader = command.ExecuteReader();
    While(reader.Read())
    {
    idValue = reader["id"].ToString();
    }
    connection.Close();
    return idValue;

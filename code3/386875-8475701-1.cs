    using (var cn = new SqlConnection(DatabaseConnection.ConnectionStringToDb))
    {
        using (var cmd = new SqlCommand("command string", cn))
        {
              // your code
        }
    }

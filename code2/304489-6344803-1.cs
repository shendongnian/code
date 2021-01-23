    private IList<int> LoadIDs()
    {
        List<int> ids = new List<int>();
        String connectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select ID from Tab1";
            command.Notification = null;
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while ((reader.Read()))
                    ids.Add((int)reader["ID"]);
            }
        }
        return ids;
    }

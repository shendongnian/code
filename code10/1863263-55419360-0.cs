    using (SqlConnection connection = this.Connections.MyConnection.AcquireConnection(null) as SqlConnection)
    {
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT [Value] FROM dbo.MyTable";
            command.CommandType = CommandType.Text;
    
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProfanityWords.Add(reader.GetValue(0).ToString());
                }
            }
        }
    
        this.Connections.MyConnection.ReleaseConnection(connection);
    }

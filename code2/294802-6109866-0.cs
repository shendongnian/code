    public static void CreateSocialGroup(string FBUID)
    {
        string query = "INSERT INTO SocialGroup (created_by_fbuid) OUTPUT INSERTED.IDENTITYCOL VALUES (@FBUID)";
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FBUID", FBUID);
            connection.Open();
            var _id = command.ExecuteScalar();
        }
    }

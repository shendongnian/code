    public IEnumerable<string> getSubject(string id, string sem, string schoolyear)
    {
        string query = "SELECT subject FROM grades WHERE student_school_id = @id AND semester= @semester AND school_year= @year";
        using (var connection = new MySqlConnection(connectionString))
        using (var cmd = new MySqlCommand(query, connection);
        {
            //use actual types and lengths for the database columns
            cmd.Parameters.Add("@id", MySqlDbType.TinyText, 10).Value = id;
            cmd.Parameters.Add("@semester", MySqlDbType.TinyText, 6).Value = semester;
            cmd.Parameters.Add("@year", MySqlDbType.TinyText, 4).Value = schoolyear;
            connection.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string result = (string)reader["subject"];
                    yield return result;
                }
            }
        }
    }

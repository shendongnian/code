    public IEnumerable<string> GetListOfUrls()
    {
        using (var conn = new SqlConnection(connectionString)
        {
            var cmd = new SqlCommand("SELECT Url FROM List", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return reader.GetString(0);
            }
        }
    }

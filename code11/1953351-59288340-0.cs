    private List<string> GetPostcodes(string table)
    {
        List<string> postcodes = new List<string>();
        using (var connect = new MySqlConnection(connectionString))
        {
            connect.Open();
            string selectString = "select postcode from " + table;
            using (MySqlCommand cmd = new MySqlCommand(selectString, connect))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        postcodes.Add(reader.GetString("postcode"));
                    }
                }
            }
        }
        return postcodes;
    }

    private List<string> ReadNews()
    {
        string SqlText = "SELECT * FROM nom_table";
        List<string> Templist = new List<string>();
        using (SqlConnection SqlConnection = new MySqlConnection(TheConnectionString))
        {
            using (MySqlCommand SqlCommand = new MySqlCommand(SqlText, SqlConnection))
            {
                using (MySqlDataReader result = SqlCommand.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Templist.Add((string)result["titre"]);
                    }
                }
    
            }
        }
        return Templist;
    }

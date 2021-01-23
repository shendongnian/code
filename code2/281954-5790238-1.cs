    public override List<string> Search(string pQuery)
    {
        string[] keywords = pQuery.Split(',');
        List<string> results = new List<string>();
        if (keywords.Length == 0)
        {
            // Code expects at least one keyword - throw exception or return null ?
        }
        StringBuilder query = new StringBuilder();
        query.Append(
            string.Format("SELECT DISTINCT name FROM table WHERE keyword LIKE '%{0}%'", keywords[0])
        );
        // Add extra keywords
        if (keywords.Length > 1)
        {
            for (int i = 1; i < keywords.Length; i++)
            {
                query.Append(string.Format(" OR keyword LIKE '%{0}%'", keywords[i]));
            }
        }
        // Add order by
        query.Append(" ORDER BY name");
        using (OleDbCommand command = new OleDbCommand(query.ToString(), sqlcon))
        {
            command.CommandType = CommandType.Text;
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(reader.GetString(0));
                }
            }
        }
        return results;
    }

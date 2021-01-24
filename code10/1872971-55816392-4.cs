        // This will build a SqlCommand from query text, and build SqlParameters
        // foreach "@Param" in the query e.g. WHERE Name = @Name and Date = @Date
        private SqlCommand GenerateSqlCommand(string queryText, params object[] paramValues)
        {
            // Build SqlCommand
            var sqlCommand = new SqlCommand(queryText);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            // Find all instances of @Param sql parameter names in the query
            var matches = Regex.Matches(queryText, @"[@#]\w+");
            for (int i = 0; i < matches.Count; i ++)
            {
                // Add this parameter to the command with the value from the paramValues
                // Parameters passed into the method must be in order 
                // E.g. if the Query is "SELECT * FROM TABLE where Name = @Name and Date = @Date
                // then paramValues must be { 'My Name', '04-24-2019' }
                sqlCommand.Parameters.AddWithValue(matches[i].Value, paramValues[i]);
            }
            // Return command
            return sqlCommand;
        }

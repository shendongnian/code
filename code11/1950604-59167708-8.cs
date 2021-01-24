    public static class BaseDadosSQL
    {
        private static string connectionString = "connection string here";
    
        private static IEnumerable<IDataRecord> QueryResult(string Query, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(Query, conn))
            {
                if (parameters is object && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
    
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader;
                    }
                }
            }
        }
    
        public static IEnumerable<IDataRecord> GetClubLogin(string clubName)
        {
            //Still guessing at type and length here.
            var p = new MySqlParameter("@SocialClub", MySqlDbType.VarString, 20);
            p.Value = clubName;
            return DB.QueryResult($"SELECT `socialclub`,`username`,`password` FROM contas WHERE socialclub = @SocialClub", p); 
        }
    }

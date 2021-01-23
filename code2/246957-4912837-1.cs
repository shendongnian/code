    private IEnumerable<BursaUser> GetUsers()
    {
        using (var conn = new SqlConnection(SomeConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT WorkerNum, CompanyName, ... FROM Users";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var user = new User
                    {
                        UserId = reader.GetInt32(reader.GetOrdinal("WorkerNum")),
                        CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                        // TODO: complete other fields
                    };
                    // TODO: do the tests and complete the complex properties
                    yield return user;
                }
            }
        }
    }

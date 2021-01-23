    public int CreateFoo()
    {
        using (var cn = new MySqlConnection(connString))
        {
            // Notice that the cmd here is not wrapped in a using or try-finally.
            using (IDbCommand cmd = CreateCommand("create foo with sql", cn))
            {
                cn.Open();
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
         }
    }

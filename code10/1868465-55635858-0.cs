    public DataTable Query(string sqlQuery)
    {
        DbProviderFactory dbFactory = DbProviderFactories.GetFactory(Database.Connection);
        using (var cmd = dbFactory.CreateCommand())
        {
            cmd.Connection = Database.Connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlQuery;
            
            //And I added this line, then problem solved.
            cmd.Transaction = Database.CurrentTransaction.UnderlyingTransaction;
            using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
            {
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }

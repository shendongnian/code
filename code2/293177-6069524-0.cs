    DataSet ds = new DataSet();
    using (OdbcConnection connection = new OdbcConnection(connectionString))
    using (OdbcCommand command = new OdbcCommand(sqlQuery, connection)
    using (OdbcDataAdapter adapter = new OdbcDataAdapter(command)
    {
        adapter.Fill(ds);
    }

    DataSet ds = new DataSet();
    
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    using (OleDbCommand command = new OleDbCommand(query, connection))
    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
    {
        adapter.Fill(ds);
    }
    return ds;

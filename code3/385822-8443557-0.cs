    public void Update(DataTable table)
    {
    OdbcConnection connection = new OdbcConnection(...);
    OdbcDataAdapter adapter = new OdbcDataAdapter("SELECT * FROM TABLENAME", connection);
    
    OdbcCommandBuilder builder = new OdbcCommandBuilder(adapter);
    adapter.UpdateCommand = builder.GetUpdateCommand();
    adapter.InsertCommand = builder.GetInsertCommand();
    adapter.DeleteCommand = builder.GetDeleteCommand();
    
    adapter.Update(table);
    }

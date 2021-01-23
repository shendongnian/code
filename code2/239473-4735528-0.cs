    public DataTable GetScheme4Table(string tableName)
    {
        DataTable ret = null;
        IDbCommand command = null;
        using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\" + DdListDatabases4GettingTables.SelectedValue + ".mdb;Persist Security Info=True"))
        {
            command = connection.CreateCommand();
            command.CommandText = string.Format("SELECT TOP 1 * FROM [{0}]", tableName);
            using (IDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo))
            {
                ret = reader.GetSchemaTable();
            }
        }
        return ret;
    }

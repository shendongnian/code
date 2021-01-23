    public DataTable ToDataTable(DataContext context, IQueryable source)
    {
        DataTable table = new DataTable();
        {
            adapter.SelectCommand = context.GetCommand(source);
            sqlCommand.Connection.Open();
            adapter.FillSchema(table, SchemaType.Source);
            adapter.Fill(table);
        }
        return table;
    }

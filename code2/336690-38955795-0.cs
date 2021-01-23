    OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
    System.Data.DataTable result = new System.Data.DataTable();
    adapter.Fill(result);
    List<string> columns = new List<string>();
    foreach(DataColumn item in result.Columns)
    {
        columns.Add(item.ColumnName);
    }
    return columns;

    public DataTable AsDataTable()
    {
        var dataTable = new dataTable(this.Name);
        foreach (var column in this.columns)
        {
            dataTable.Columns.Add(new DataColumn(
                column.Name,
                column.Type ?? typeof(string)));
        }
        foreach (var row in this.rows)
        {
            object[] values = new object[dataTable.Columns.Count];
            for (int cc = 0; cc < row.Length; ++cc)
            {
                values[cc] = Convert.ChangeType(row[cc],
                    dataTable.Columns[cc].DataType);
            }
            dataTable.LoadRow(values, false);
        }
        return dataTable;
    }

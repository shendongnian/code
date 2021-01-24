c#
        DataTable dataTable = GetData();
        var data = new List<Dictionary<string, object>>();
        foreach (DataRow dataTableRow in dataTable.Rows)
        {
            var dic = new Dictionary<string, object>();
            foreach (DataColumn tableColumn in dataTable.Columns)
            {
                dic.Add(tableColumn.ColumnName, dataTableRow[tableColumn]);
            }
            data.Add(dic);
        }

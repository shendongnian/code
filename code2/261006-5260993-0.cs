    private DataTable DataTableJoiner(DataTable dt1, DataTable dt2)
        {
            var commonColumns = dt1.Columns.OfType<DataColumn>().Intersect(dt2.Columns.OfType<DataColumn>(), new DataColumnComparer());
            var result = new DataTable();
            result.Columns.AddRange(
                dt1.Columns.OfType<DataColumn>()
                .Union(dt2.Columns.OfType<DataColumn>(), new DataColumnComparer())
                .Select(c => new DataColumn(c.Caption, c.DataType, c.Expression, c.ColumnMapping))
                .ToArray());
            var rowData = dt1.AsEnumerable().Join(
                dt2.AsEnumerable(),
                row => commonColumns.Select(col => row[col.Caption]).ToArray(),
                row => commonColumns.Select(col => row[col.Caption]).ToArray(),
                (row1, row2) => 
                {
                    var row = result.NewRow();
                    row.ItemArray = result.Columns.OfType<DataColumn>().Select(col => row1.Table.Columns.Contains(col.Caption) ? row1[col.Caption] : row2[col.Caption]).ToArray();
                    return row;
                },
                new ObjectArrayComparer());
            foreach (var row in rowData)
                result.Rows.Add(row);
            return result;
        }

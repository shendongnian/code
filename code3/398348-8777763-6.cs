     DataTable table = new DataTable();
            foreach (DataColumn column in t1.Columns)
            {
                table.Columns.Add(column.ColumnName, column.DataType);
            }
            foreach (DataColumn column in t2.Columns)
            {
                if (column.ColumnName == "Location")
                    table.Columns.Add(column.ColumnName + "2", column.DataType);
                else
                    table.Columns.Add(column.ColumnName, column.DataType);
            }
            var results = t1.AsEnumerable().Join(t2.AsEnumerable(),
                    a => a.Field<String>("Location"),
                    b => b.Field<String>("Location"),
                    (a, b) =>
                    {
                        DataRow row = table.NewRow();
                        row.ItemArray = a.ItemArray.Concat(b.ItemArray).ToArray();
                        table.Rows.Add(row);
                        return row;
                    });

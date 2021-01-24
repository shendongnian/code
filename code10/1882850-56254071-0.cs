    List<string> names = new List<string>();
                DataTable table = new DataTable();
                DataRow firstRow = table.NewRow();
                foreach (DataColumn column in dt.Columns)
                {
                    names.Add(column.ColumnName);
                    table.Columns.Add(column.ColumnName, typeof(string));
                }
                firstRow.ItemArray = names.ToArray();
                table.Rows.InsertAt(firstRow, 0);

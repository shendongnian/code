        public static void AddRowFromExistingTable(this DataTable table, DataRow otherTableRow)
        {
            var newRow = table.NewRow();
            foreach (DataColumn col in table.Columns)
            {
                newRow[col.ColumnName] = otherTableRow[col.ColumnName];
            }
            table.Rows.Add(newRow);
        }

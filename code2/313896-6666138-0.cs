            DataTable table = CreateDataTable();
            foreach (DataColumn column in table.Columns)
            {
                dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
            }
            //there is you code too here.

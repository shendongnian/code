    public static class DataTableExtensions
    {
        public static void MergeRange(this DataTable dest, DataTable table, int startIndex, int length)
        {
            List<string> matchingColumns = new List<string>();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                // Only copy columns with the same name and type
                string columnName = table.Columns[i].ColumnName;
                if (dest.Columns.Contains(columnName))
                {
                    if (dest.Columns[columnName].DataType == table.Columns[columnName].DataType)
                    {
                        matchingColumns.Add(columnName);
                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                int row = i + startIndex;
                DataRow destRow = dest.NewRow();
                foreach (string column in matchingColumns)
                {
                    destRow[column] = table.Rows[row][column];
                }
                dest.Rows.Add(destRow);
            }
        }
    }

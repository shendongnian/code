    private void PrintColumnNames(DataSet dataSet)
    {
        // For each DataTable, print the ColumnName.
        foreach(DataTable table in dataSet.Tables)
        {
            foreach(DataColumn column in table.Columns)
            {
                Console.WriteLine(column.ColumnName);
            }
        }
    }

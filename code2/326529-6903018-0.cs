    private DataTable PivotTable(DataTable origTable)
    {
        DataTable newTable = new DataTable();
        DataRow dr = null;
        //Add Columns to new Table
        for (int i = 0; i <= origTable.Rows.Count; i++)
        {
            newTable.Columns.Add(new DataColumn(origTable.Columns[i].ColumnName, typeof(String)));
        }
        //Execute the Pivot Method
        for (int cols = 0; cols < origTable.Columns.Count; cols++)
        {
            dr = newTable.NewRow();
            for (int rows = 0; rows < origTable.Rows.Count; rows++)
            {
                if (rows < origTable.Columns.Count)
                {
                    dr[0] = origTable.Columns[cols].ColumnName; // Add the Column Name in the first Column
                    dr[rows + 1] = origTable.Rows[rows][cols];
                }
            }
            newTable.Rows.Add(dr); //add the DataRow to the new Table rows collection
        }
        return newTable;
    }

    // Set up a List<T> to hold the indexes of the visible columns
    List<int> visibleColumns = new List<int>();
    foreach (DataGridViewColumn col in dgv1.Columns)
    {
        if (col.Visible)
        {
            dgv2.Columns.Add((DataGridViewColumn)col.Clone());
            visibleColumns.Add(col.Index);
        }
    }
    // Now add the data from the columns
    // Set a counter for the current row index for the second DataGridView
    int rowIndex = 0;
    foreach (DataGridViewRow row in dgv1.Rows)
    {
        // Add a new row to the DataGridView
        dgv2.Rows.Add();
        // Loop through the visible columns
        for (int i = 0; i < visibleColumns.Count; i++)
        {
            // Use the index of the for loop for the column in the target data grid
            // Use the index value from the List<T> for the cell of the source target data grid
            dgv2.Rows[rowIndex].Cells[i].Value = row.Cells[visibleColumns[i]].Value;
        }
        // Increment the rowIndex
        rowIndex++;
    }

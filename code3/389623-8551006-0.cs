    if (e.ColumnIndex == 1)
    {
        // Get a reference to the cell of interest.
        DataGridViewCell quantity = dataGridViewOrderDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];
        // Update its value.
        quantity.Value = 100;  // or whatever your new value is
    }

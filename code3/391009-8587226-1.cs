    foreach (DataGridViewRow fees_row in this.dataGridView2.Rows)
    {
        var cell = fees_row.Cells[0];
        if (cell != null)
        {
            var value = cell.Value;
            if (value != null && (bool)value == true)
            {
                // Do whatever...
            }
        }
    }

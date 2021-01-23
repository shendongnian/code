    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
        if (e.ColumnIndex == dataGridView1.Columns[nameOrIndexOfYourImageColumn].Index) {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 
            // another cell in the same row (see my note below).
            cell.ToolTipText = dataGridView1.Rows[e.RowIndex].Cells[nameOrIndexOfYourDescriptionColumn].Value.ToString();
        }
    }

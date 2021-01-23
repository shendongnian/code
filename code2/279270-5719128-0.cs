    private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e) {
        if (e.ColumnIndex == 2) {     // Display the tool tip only on DGV ColumnIndex 2.
            Rectangle cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            toolTip1.Show("This is my ToolTip text",
                          this,
                          dataGridView1.Location.X + cellRect.X + cellRect.Size.Width, 
                          dataGridView1.Location.Y + cellRect.Y + cellRect.Size.Height, 
                          5000);    // Duration: 5 seconds.
        }
    }

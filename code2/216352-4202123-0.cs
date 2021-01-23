    private void DGV_MouseUp(object sender, MouseEventArgs e)
    {
        // This gets information about the cell you clicked.
     System.Windows.Forms.DataGridView.HitTestInfo ClickedInfo = DGV.HitTest(e.X, e.Y);
        // This is so that the header row cannot be deleted
     if (ClickedInfo.ColumnIndex >= 0 && ClickedInfo.RowIndex >= 0)
            // This sets the current row
      DataViewMain.CurrentCell = DGV.Rows[ClickedInfo.RowIndex].Cells[ClickedInfo.ColumnIndex];
    }

    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e) {
        var cell = dataGridView1.CurrentCell;
        var cellDisplayRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
        toolTip1.Show(string.Format("this is cell {0},{1}", e.ColumnIndex, e.RowIndex), 
                      dataGridView1,
                      cellDisplayRect.X + cell.Size.Width / 2,
                      cellDisplayRect.Y + cell.Size.Height / 2,
                      2000);
        dataGridView1.ShowCellToolTips = false;
    }

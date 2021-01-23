    private void datagridView12_KeyDown(object sender, KeyEventArgs e) 
    { 
         if (e.KeyCode == Keys.Enter) 
         {
             int col = dataGridView12.CurrentCell.ColumnIndex;
             int row = dataGridView12.CurrentCell.RowIndex;
             if (row != dataGridView12.NewRowIndex)
             {
                 if (col == (dataGridView12.Columns.Count - 1))
                 {
                     col = -1;
                     row++;
                 }
                 dataGridView12.CurrentCell = dataGridView12[col, row + 1];
             }
             e.Handled = true;
             base.OnKeyDown(e);
         } 
    }

     private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
    
                grd.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool Result = Convert.ToBoolean((grd[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell).Value);
            }

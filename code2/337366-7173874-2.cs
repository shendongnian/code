    private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
	    if (e.ColumnIndex >= 0 & e.RowIndex >= 0) 
        {
            ToolTip1.SetToolTip(dgv, Convert.ToString(dgv.Item(e.ColumnIndex, e.RowIndex).Tag));
        }
    }

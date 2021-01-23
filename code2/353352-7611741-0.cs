    void dgUpdateItems_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dg = (DataGridView)sender;
        if (e.ColumnIndex == dg.Columns["ItemCategory"].Index)
        {
            if (e.ColumnIndex == e.RowIndex)
            {
                dg[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                return;
            }
            DataGridViewComboBoxCell cmbCell = new DataGridViewComboBoxCell();
            ComboUpdate(cmbCell);
            cmbCell.Value = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value.ToString();
            ((DataGridView)sender)[e.ColumnIndex, e.RowIndex] = cmbCell;
        }
    }
    
    void dgUpdateItems_CellLeave(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dg = (DataGridView)sender;
        if (e.ColumnIndex == dg.Columns["ItemCategory"].Index)
        {
            if (e.ColumnIndex == e.RowIndex)
                return;
    
            string str = dg[e.ColumnIndex, e.RowIndex].Value.ToString();
            DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)dg[e.ColumnIndex, e.RowIndex];
            string val = cmb.Value.ToString();
    
            dg[e.ColumnIndex, e.RowIndex] = new DataGridViewTextBoxCell();
            dg[e.ColumnIndex, e.RowIndex].Value = val;

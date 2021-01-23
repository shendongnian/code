    private void YourDGV_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (YourDGV.CurrentCell.ColumnIndex == rateColumnIndex)
        {
            YourDGV.CommitEdit(DataGridViewDataErrorContexts.Commit);                        
        }
    }
    private void YourDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == rateColumnIndex)
        {
            DataGridViewTextBoxCell cellAmount = YourDGV.Rows[e.RowIndex].Cells[amountColumnIndex];
            DataGridViewTextBoxCell cellQty = YourDGV.Rows[e.RowIndex].Cells[qtyColumnIndex];
            DataGridViewTextBoxCell cellRate = YourDGV.Rows[e.RowIndex].Cells[rateColumnIndex];
            cellAmount.Value = (int)cellQty.Value * (int)cellRate.Value;
        }
    }

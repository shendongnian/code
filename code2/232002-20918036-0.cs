    private void datagridview_CurrentCellDirtyStateChanged(Object sender, EventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        if(_checkboxColumnIndex = e.ColumnIndex && dgv.Columns[_checkboxColumnIndex].GetType() = typeof(DataGridViewCheckBoxColumn))
        {
            
            //Remember that here dgv.CurrentCell.Value is previous/old value yet
            YourObject.HasCustomValue = !(bool)dgv.CurrentCell.Value
        }
	dgv.CommitEdit(DataGridViewDataErrorContexts.Commit) //this will fire .CellEndEdit event
    }

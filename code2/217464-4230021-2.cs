    private void dataGridView1_EditingControlShowing(object sender, 
            DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox c = e.Control as ComboBox;
        if (c != null) c.DropDownStyle = ComboBoxStyle.DropDown;
    }
    
    private void dataGridView1_CellValidating(object sender, 
            DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == comboBoxColumn.Index)
        {
            object eFV = e.FormattedValue;
            if (!comboBoxColumn.Items.Contains(eFV))
            {
                comboBoxColumn.Items.Add(eFV);
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
            }
        }
    }

    string value = DataGridView.Rows[RowIndex].Cells[ColumnIndex].Value.ToString();
    
    if DataGridView.Rows[RowIndex].Cells[ColumnIndex] is DataGridViewComboBoxCell && !string.IsNullOrEmpty(value))
    {
         List<ListItem> items = ((DataGridViewComboBoxCellDataGridView.Rows[RowIndex].Cells[e.ColumnIndex]).Items.Cast<ListItem>().ToList();
         ListItem item = items.Find(i => i.Value.Equals(value));
    }

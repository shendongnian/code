    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        foreach (DataGridViewColumn column in dataGridView1.Columns)
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.ColumnCount = 3;
        dataGridView1.RowCount = 3;
        foreach (DataGridViewColumn c in dataGridView1.Columns)
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
    }
    private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        dataGridView1.ClearSelection();
        if (e.ColumnIndex == -1 && e.RowIndex == -1)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            dataGridView1.SelectAll();
        }
        else if (e.ColumnIndex == -1 && e.RowIndex > -1)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
        else if (e.ColumnIndex > -1 && e.RowIndex == -1)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            dataGridView1.Columns[e.ColumnIndex].Selected = true;
        }
        else
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }
    }

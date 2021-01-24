    DataGridViewTextBoxColumn tc = new DataGridViewTextBoxColumn();
    tc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    dataGridView1.Columns.Add(tc);
    // Hide row&column header
    dataGridView1.ColumnHeadersVisible = false;
    dataGridView1.RowHeadersVisible = false;
    // Hide border
    dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

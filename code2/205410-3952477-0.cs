    private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
    dataGridView1[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Red;
    }
    
    private void DataGridView_CellLeave1(object sender, DataGridViewCellEventArgs e)
    {
    dataGridView1[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Blue;
    }

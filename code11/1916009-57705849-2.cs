    DataTable dt;
    private void Form1_Load(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt.Columns.Add("Phone1");
        dt.Columns.Add("Phone2");
        dt.Rows.Add("123", "456");
        dt.Rows.Add(DBNull.Value, "789");
        dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
        dataGridView1.DataSource = dt;
    }
    private void DataGridView1_CellEndEdit(object sender, 
        DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            dataGridView1.InvalidateCell(0, e.RowIndex);
    }
    private void DataGridView1_CellFormatting(object sender, 
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex >= 0)
        {
            if (e.Value == DBNull.Value)
            {
                var otherValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                if (otherValue != DBNull.Value)
                {
                    //If you want just display value of the other cell
                    e.Value = otherValue;
                    
                    // If you want display and push value of other cell into this cell
                    //((DataRowView)dataGridView1.Rows[e.RowIndex]
                    //       .DataBoundItem)[e.ColumnIndex] = otherValue;
                }
            }
        }
    }

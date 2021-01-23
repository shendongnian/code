    DataGridView1.CellContentDoubleClick += DataGridView1_CellContentDoubleClick;
    
    private void DataGridView1_CellContentDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
       Player player = DataGridView1.Rows(e.RowIndex).DataBoundItem as Player;
    }

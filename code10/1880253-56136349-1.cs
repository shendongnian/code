    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        var bd = (BindingSource)dataGridView1.DataSource;
        var dt = (DataTable)bd.DataSource;
        dt.DefaultView.RowFilter = string.Format("FirstName like '%{0}%'", SearchTextBox.Text.Trim().Replace("'", "''"));    
        dataGridView1.Refresh();
    }

    private DataTable LoadData()
    {
        var dt = new DataTable();
        dt.Columns.Add("C1", typeof(int));
        dt.Rows.Add(1);
        dt.Rows.Add(11);
        dt.Rows.Add(2);
        dt.Rows.Add(22);
        return dt;       
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.DataSource = LoadData();
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var filter = "";
        if (!string.IsNullOrEmpty(textBox1.Text))
            filter = $"Convert([C1], System.String) = '{textBox1.Text}'";
        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
    }

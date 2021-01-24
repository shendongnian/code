    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // Define a datatable
        DataTable dt = new DataTable("tablename");
        DataRow dr;
        dt.Columns.Add("iView", System.Type.GetType("System.String"));
        dt.Columns.Add("kView", System.Type.GetType("System.String"));
        dt.Columns.Add("cView", System.Type.GetType("System.String"));
        for (int i = 0; i < this.dataGridView1.Rows.Count -1; i++)
        {
            dr = dt.NewRow();
            for (int j = 0; j < 3; j++)
            {
                dr[j] = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
            }
            dt.Rows.Add(dr);
        }
        // Filter
        BindingSource bs = new BindingSource();
        bs.DataSource = dt;
        bs.Filter = "iView like '%" + textBox1.Text + "%'";
        bs.Filter = "kView like '%" + textBox1.Text + "%'";
        bs.Filter = "cView like '%" + textBox1.Text + "%'";
        // Reset the datagridview content
        dataGridView1.Columns.Clear();
        dataGridView1.DataSource = bs;
    }

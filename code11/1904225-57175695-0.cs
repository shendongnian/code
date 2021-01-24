        DataTable dt = new DataTable();
        private void Button1_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Clear();
            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");
            dt.Rows.Add("a", "a", "a");
            dataGridView1.DataSource = dt;
        }
    
        private void Button2_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Clear();
            dt.Columns.Add("X");
            dt.Columns.Add("Y");
            dt.Columns.Add("Z");
            dt.Rows.Add("b", "b", "b");
            dataGridView1.DataSource = dt;
        }

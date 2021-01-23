        private void Main_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("colCustomers", typeof(string));
            dt.Rows.Add(new object[] { "1 John" });
            dt.Rows.Add(new object[] { "2 Kate" });
            dt.Rows.Add(new object[] { "3 Jill" });
            comboBox1.DataSource = dt.DefaultView; //allows us to filter the results
            comboBox1.DisplayMember = "Col1";
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                dt.DefaultView.RowFilter = "colCustomers LIKE '%" + comboBox1.Text + "%'";
            }
        }

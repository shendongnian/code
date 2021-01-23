    private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("A1", typeof(int));
                dt.Columns.Add("A2");
                dt.Rows.Add(1, "A");
                dt.Rows.Add(2, "B");
    
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "A2";
                comboBox1.ValueMember = "A1";
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                MyDataGridView.Columns.Insert(0, new DataGridViewCheckBoxColumn());
                MyDataGridView.Rows.Add(4);
                MyDataGridView.Rows[0].Cells[0].Value = true;
                MyDataGridView.Rows[1].Cells[0].Value = false;
                MyDataGridView.Rows[2].Cells[0].Value = true;
                MyDataGridView.Rows[4].Cells[0].Value = true;
    
                int strResults = MyDataGridView.Rows.Cast<DataGridViewRow>()
                               .Where(c => Convert.ToBoolean(c.Cells[0].Value).Equals(true)).ToList().Count;
                MessageBox.Show("" + strResults);
            }

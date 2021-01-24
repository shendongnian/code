            string[] row1 = new string[] { "A1", "A2", "A3" };
            string[] row2 = new string[] { "B1", "B2", "B3" };
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach(DataGridViewColumn col in dataGridView1.Columns)
                {
                 string s = string.Format("I am at row {0} , col{1} the value is {2}", row.Index, col.Index, (string)dataGridView1.Rows[row.Index].Cells[col.Index].Value);
                    MessageBox.Show(s);
                }
            }
        }

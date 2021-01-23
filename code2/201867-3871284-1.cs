      private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal sum = 0.00m;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[1, i].Value != DBNull.Value)
                {
                    sum = sum + Convert.ToDecimal(dataGridView1[1, i].Value);
                    textBox1.Text = sum.ToString("f2");
                }
            }
        }
 

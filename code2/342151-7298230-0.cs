     private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].IsNewRow)
                {
                    if (dataGridView1[0, i].Value.ToString() == textBox1.Text)
                        dataGridView1.Rows[i].Selected = true;
                    else
                        dataGridView1.Rows[i].Selected = false;
                }
            }
        }

            if (listBoxContacts.SelectedItem != null)
                foreach (string item in listBoxContacts.SelectedItems)
                {
                    int A = dataGridView1.Rows.Add();
                    // dataGridView1.Rows[index].Cells[textBox1.Text].Value = item;
                    dataGridView1.Rows[A].Cells[0].Value = textBox1.Text;
                    dataGridView1.Rows[A].Cells[1].Value = textBox3.Text;
                    dataGridView1.Rows[A].Cells[2].Value = textBox4.Text;
                    dataGridView1.Rows[A].Cells[3].Value = textBox5.Text;
                    dataGridView1.Rows[A].Cells[4].Value = textBox6.Text;
                }

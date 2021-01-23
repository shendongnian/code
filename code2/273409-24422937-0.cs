          try
            {
                for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                {
                    for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                    {
                        s1 = dataGridView1.Rows[0].Cells[0].Value.ToString();
                        label20.Text = s1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("try again"+ex);
            }

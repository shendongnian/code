        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                r.Visible = false;
                foreach (DataGridViewCell c in r.Cells)
                    if (c.Value.ToString().Contains(textBox1.Text))
                    {
                        r.Visible = true;
                        break;
                    }
            }
        }

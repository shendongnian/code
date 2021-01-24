        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                if (textBox2.Text == row.Cells["columnName"].Value.ToString())
                {
                    MessageBox.Show("Duplicate.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

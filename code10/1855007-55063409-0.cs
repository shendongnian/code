        private void button2_Click(object sender, System.EventArgs e)
        {
            dataGridView2.Rows.Clear();
            var filterText = textBox1.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToString(row.Cells[0].Value).Contains(filterText))
                {
                    var filteredRow = (DataGridViewRow)row.Clone();
                    //Copy values from one DataGridViewRow to another
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        filteredRow.Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                    dataGridView2.Rows.Add(filteredRow);
                }
            }
        }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
                if (e.ColumnIndex == myCheckBoxColumnName.Index) {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string name = row.Cells["Name"].Value.ToString();
                    string amount = row.Cells["Amount"].Value.ToString();
                    dataGridView2.Rows.Add(name, amount);
                }
            }

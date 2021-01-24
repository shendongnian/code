      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
    
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string value = selectedRow.Cells["name"].Value.ToString();
    
                    txtpresup.Text = value;
                }
            }
        }

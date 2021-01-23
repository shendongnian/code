    if (dataGridView1.SelectedRows.Count > 0)
          {
             foreach (DataGridViewRow row in dataGridView1.Rows)
               {
                   TextBox1.Text = row.Cells["ColumnName"].Value.ToString();
               }
          }
    else
          {
            MessageBox.Show("Please select item!");
          }
         }

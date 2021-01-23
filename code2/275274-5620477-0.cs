     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
     {
          if (e.ColumnIndex == 0)
          {
               dataGridView1.Rows.RemoveAt(e.RowIndex);
          }
     }

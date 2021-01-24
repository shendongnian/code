    private void updateExcel_Click(object sender, EventArgs e)
    {
       for (int i = 0; i < dataGridView1.RowCount; i++)
       {
          if (!RowIsEmpty(i))
          {
              dataGridView1[2, i].Value = Combo.Text;
          }
       }
    }

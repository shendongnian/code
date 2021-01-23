     decimal Total = 0;
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        Total+= Convert.ToDecimal(dataGridView1.Rows[i].Cells["ColumnName"].Value);
      }
    labelName.Text = Total.ToString();

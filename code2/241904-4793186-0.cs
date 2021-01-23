    if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "Discontinued")
    {
      if (dataGridView1[reqdColumnIndex, e.RowIndex].FormattedValue as bool)
      {
        e.CellStyle.ForeColor = Color.Gray;
      }
    }

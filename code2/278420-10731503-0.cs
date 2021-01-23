    private void DataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
    {
      if (e.Column.Index == 0)
      {
        e.Column.ValueType = typeof(int);
        e.Column.CellTemplate.ValueType = typeof(int);
      }
    }

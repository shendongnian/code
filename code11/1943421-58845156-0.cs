    private void Form1_Load(object sender, EventArgs e)
    {
      for (int i = 0; i < dataGridView1.ColumnCount; i++)
      {
        dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
      }
      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
    }

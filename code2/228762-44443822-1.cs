    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
          for (int i = 0; i < dataGridView1.Columns.Count; i++)
          {
               dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
          }
    }
    
    

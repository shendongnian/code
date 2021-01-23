    for (int i = 0; i < dataGridView1.Columns.Count; i++)
    {
       // Size the column header based on the ColumnHeader mode
       dataGridView1.Columns[i].AutoSizeMode = 
          DataGridViewAutoSizeColumnMode.ColumnHeader;
       // Store autosized width
       int colw = dataGridView1.Columns[i].HeaderCell.PreferredSize.Width;
       // Change back to Resize mode
       dataGridView1.Columns[i].AutoSizeMode = 
          DataGridViewAutoSizeColumnMode.None;
       // Set width to calculated above
       dataGridView1.Columns[i].Width = colw;
    }

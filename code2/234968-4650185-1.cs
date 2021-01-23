    DataGridViewColumn[] columns = new DataGridViewColumn[dt.Columns.Count];
    for (int i = 0; i < dt.Columns.Count; i++ )
    {
        DataColumn c = dt.Columns[i];
        DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
        col.SortMode = DataGridViewColumnSortMode.NotSortable;
        col.DataPropertyName = c.ColumnName;
        col.HeaderText = c.Caption;
                
        columns[i] = col;
    }
    dataGridView1.Columns.AddRange(columns);

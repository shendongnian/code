    DataGridViewColumn c = new DataGridViewColumn();
    c.Name = "ColumnName";
    c.HeaderText = "DisplayText";
    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    c.CellTemplate = new DataGridViewTextBoxCell();
    dataGridView1.Columns.Add(c);

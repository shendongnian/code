    List<string> names = new List<string> { "Joe", "Sally", "Kate" };
    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    col.DataSource = names;
    col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    dataGridView1.Columns.Add(col);

	string checkBoxColumnName = "IsMale"; // CheckBox column name
	string outputColumnName = "MyId"; // Cell column name you want to value from.
	var headerColumn = dataGridView1.Columns.Cast<DataGridViewColumn>().Single(c => c.Name == checkBoxColumnName);
	var r = dataGridView1.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => (bool)(row.Cells[headerColumn.Index].Value));
	var result = r.Cells[outputColumnName].Value.ToString(); // result as string

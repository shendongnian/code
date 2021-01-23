	DataGridViewCell cell = (DataGridViewCell) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
	if (cell.ColumnIndex == this.dataGridView1.Columns["YourColumn"].Index)
	{
		// Do something when a "YourColumn" cell is clicked
	}
	else if (cell.ColumnIndex == this.dataGridView1.Columns["AnotherColumn"].Index)
	{
		// Do something when an "AnotherColumn" cell is clicked
	}

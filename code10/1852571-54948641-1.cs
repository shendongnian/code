private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
	var gridView = (DataGridView)sender;
	if (gridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
		e.RowIndex >= 0)
	{
		//TODO: Button was clicked. Check the index of the row and do you specialized work for different rows.
	}
}
Thats the code for the event, you have to bind that to the datagrid and write the switch/ifs using the rowIndex to have different functionality for each button.
Hope it helps!
------------------------------------------------------------------------------
Added after reading extra comments and edition made on original question:
private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
	var gridView = (DataGridView)sender;
	if (gridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
		e.RowIndex >= 0)
	{
		string typeOfRow = gridView.Rows[e.RowIndex].Cells[2 /*Column that defines the type of action to take*/].ToString();
		if (typeOfRow == "ShowMessage")
		{
			// Here i just copied the logic you added, dont know if it makes sense. 
			MessageBox.Show((e.RowIndex + 1).ToString() + " Information");
			//I would assume you want to do this instead:
			MessageBox.Show((gridView.Rows[e.RowIndex].Cells[3/*number of column with data to show*/]).ToString() + " Information");
		}
	}
}

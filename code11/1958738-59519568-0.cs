C#
// Predefined stuff:
DataTable sourceDT;
DataTable targetDT;
DataGrid sourceDAGRI;
private void WorkerRowSource_MouseDoubleClick(object sender, MouseButtonEventArgs e)
{
	var rowView = sender as DataGridRow;
	var cellContent = sourceDAGRI.Columns[1].GetCellContent(rowView);
	int num = int.Parse((cellContent as TextBlock).Text);
	
	DataRow row = null;
	foreach (DataRow dRow in sourceDT.Rows)
		if ((int)dRow[_numKey] == num)
		{
			row = dRow;
			break;
		}
	targetDT.ImportRow(row);
	sourceDT.Rows.Remove(row);
}
This gets the value of the cells in the DataGridRow and attempts to find a row that has the same Values in the DataTable (so that I dont rely on DataGridRow.GetIndex()).

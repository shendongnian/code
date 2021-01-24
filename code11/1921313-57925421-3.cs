    int dateIndex = 0;
	DataTable gridSource = dtexcel2.Copy();         // a new DataTable with same content
	gridSource.Columns.RemoveAt(dateIndex);			// remove the DateTime column
	string colName = dtexcel2.Columns[dateIndex].ColumnName;
	DataColumn newColumn = gridSource.Columns.Add(colName); // string column
	newColumn.SetOrdinal(dateIndex);                        // new string column will take the place
	for (int i = 0; i < gridSource.Rows.Count; i++)
	{
		string dateWithoutTime = dtexcel2.Rows[i].Field<DateTime>(dateIndex).ToShortDateString();
		gridSource.Rows[i].SetField<string>(newColumn, dateWithoutTime);
	}

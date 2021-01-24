    sda.Fill(dtexcel2); // here ends your code
	DataTable gridSource = dtexcel2.Copy();
	int oldColumnIndex = 0;
	string colName = dtexcel2.Columns[oldColumnIndex].ColumnName;
	string oldColumnName = $"{colName}_OLD_COLUMN_NAME";
	gridSource.Columns[oldColumnIndex].ColumnName = oldColumnName; // we cant have 2 columns with same name
	DataColumn col = gridSource.Columns.Add(colName);
	col.SetOrdinal(oldColumnIndex); // new string column will take the place
	foreach (DataRow row in gridSource.Rows)
		row.SetField<string>(col, row.Field<DateTime>(oldColumnName).ToShortDateString());
    gridSource.Columns.Remove(oldColumnName);

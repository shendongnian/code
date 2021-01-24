    sda.Fill(dtexcel2); // here ends your code
	DataTable gridSource = dtexcel2.Copy();
	DataColumn oldColumn = dtexcel2.Columns[0];
	string colName = oldColumn.ColumnName;
	oldColumn.ColumnName = $"{colName}_OLD_COLUMN_NAME";
	DataColumn newColumn = gridSource.Columns.Add(colName);
	newColumn.SetOrdinal(0); // new string column will take the place
	foreach (DataRow row in gridSource.Rows)
		row.SetField<string>(newColumn, row.Field<DateTime>(oldColumn).ToShortDateString());
	gridSource.Rows.Remove(oldColumn); // not needed anymore

for (int i = 0; i &lt; dataTable.Rows.Count; i++)
{
	DataRow row = dataTable.Rows[i];
	if (row["ColumnA"] == DBNull.Value)
	{
		row["ColumnA"] = 0;
	}
}

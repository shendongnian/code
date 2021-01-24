	foreach (IXLRow row in workSheet.Rows())
	{
		while (firstRow)
		
		{
			foreach (IXLCell cell in row.Cells())
			{
			dt.Columns.Add(cell.Value.ToString());
			}
			
			dt.Columns.Add(new DataColumn("OK", typeof(bool)));
			dt.Columns.Add(new DataColumn("Datum", typeof(string)));
			firstRow = false;
			continue;  // go to next row
		}
		dt.Rows.Add();
		int i = 0;
		foreach (IXLCell cell in row.Cells())
		{
			dt.Rows[dt.Rows.Count-1][i] = cell.Value.ToString();
			i++;
		}
    }
	Dgv_Data_List.DataSource = dt;
	Dgv_Data_List.ReadOnly = true;

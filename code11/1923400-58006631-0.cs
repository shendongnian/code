	DataTable dt = new DataTable();
	dt.Columns.Add("V1",typeof(int));
	dt.Columns.Add("V2",typeof(int));
	dt.Columns.Add("V3",typeof(int));
	dt.Columns.Add("V4",typeof(int));
	DataTable myTable = dt.Clone();
	int v1 = 1;
	int v2 = 2;
	int v3 = 3;
	int i = 0;
	DataRow dr = dt.NewRow();
	int?[] codCell = { v1, v2, null, v3 };
	while (i < codCell.Length)
	{
		dr[i] = codCell[i] ?? (object)DBNull.Value;
		i++;
	}
	myTable.ImportRow(dr);

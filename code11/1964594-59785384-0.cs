    DataTable dt2 = new DataTable();
	dt2.Columns.Add("Col0");
	dt2.Columns.Add("Col1");
	dt2.Columns.Add("Col2");
	dt2.Columns.Add("Col3");
	dt2.Columns.Add("Col4");
	dt2.Columns.Add("Col5");
	dt2.Columns.Add("Col6");
	var lines = File.ReadAllLines(@"file path"); //C:\ToBeDeleted\test.txt
	for (int i = 0; i < lines.Length; i++)
	{
		var str = lines[i];
		var strarray = str.Split('|');
		DataRow drow = dt2.NewRow();
		drow["Col0"] = strarray[0];
		drow["Col1"] = strarray[1];
		drow["Col2"] = strarray[2];
		drow["Col3"] = strarray[3];
		drow["Col4"] = strarray[4];
		drow["Col5"] = strarray[5];
		drow["Col6"] = strarray[6];
		dt2.Rows.Add(drow);
	}

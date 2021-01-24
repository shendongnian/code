	[TestMethod]
	public void Row_Multiple_Grouping_Test()
	{
		//https://stackoverflow.com/questions/57925761/how-to-add-multiple-collapse-in-same-outline-using-epplus-c-sharp
		//Throw in some data
		var dataTable = new DataTable("tblData");
		dataTable.Columns.AddRange(new[]
		{
			new DataColumn("Header", typeof (string)),
			new DataColumn("Col1", typeof (int)),
			new DataColumn("Col2", typeof (int)),
			new DataColumn("Col3", typeof (object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = dataTable.NewRow();
			row[0] = $"Header {i}";
			row[1] = i; row[2] = i * 10;
			row[3] = Path.GetRandomFileName();
			dataTable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Row_Multiple_Grouping_Test.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(dataTable, true);
			//First grouping of Level 1
			for (var i = 2; i <= 6; i++)
			{
				worksheet.Row(i).OutlineLevel = 1;
				worksheet.Row(i).Collapsed = true;
			}
			//Create a gap - cant shrink or hide it because it hides the collapse button in GUI
			worksheet.InsertRow(7, 1);
			//Second grouping of Level 1
			for (var i = 8; i <= 12; i++)
			{
				worksheet.Row(i).OutlineLevel = 1;
				worksheet.Row(i).Collapsed = true;
			}
			pck.Save();
		}
	}

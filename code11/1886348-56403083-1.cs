	[TestMethod]
	public void ReplaceXmlTest()
	{
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Col1", typeof (int)),
			new DataColumn("Col2", typeof (int)),
			new DataColumn("Col3", typeof (string))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = i;
			row[1] = i * 10;
			row[2] = i % 2 == 0 ? "ABCD" : "AXCD";
			datatable.Rows.Add(row);
		}
		using (var pck = new ExcelPackage())
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("source");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			worksheet.Tables.Add(worksheet.Cells["A1:C11"], "Table1");
			//Now similulate the copy/open of the excel file into a zip archive
			using (var orginalzip = new ZipArchive(new MemoryStream(pck.GetAsByteArray()), ZipArchiveMode.Read))
			{
				var fi = new FileInfo(@"c:\temp\ReplaceXmlTest.xlsx");
				if (fi.Exists)
					fi.Delete();
				orginalzip.ReplaceXmlString(fi, "AXCD", "REPLACED!!");
			}
		}
	}

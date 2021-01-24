	[TestMethod]
	public void Column_Border()
	{
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new DataColumn[] {
			new DataColumn("Col0", typeof(object)),
			new DataColumn("Col1", typeof(int)),
			new DataColumn("Col2", typeof(int)),
			new DataColumn("Col3", typeof(object))
		});
		for (int i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = Path.GetRandomFileName();
			row[1] = i;
			row[2] = i * 10;
			row[3] = Path.GetRandomFileName();
			datatable.Rows.Add(row);
		}
		var fi = new FileInfo("c:\\temp\\Column_Border.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (ExcelPackage pck = new ExcelPackage(fi))
		{
			var WorkSheet = pck.Workbook.Worksheets.Add("source");
			WorkSheet.Cells["A1"].LoadFromDataTable(datatable, true);
			WorkSheet.View.ShowGridLines = false;
			var allCells = WorkSheet.Cells;
			allCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			allCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
			allCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
			allCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
			allCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
			allCells.Style.Border.Top.Color.SetColor(Color.Green);
			allCells.Style.Border.Bottom.Color.SetColor(Color.Green);
			allCells.Style.Border.Left.Color.SetColor(Color.Green);
			allCells.Style.Border.Right.Color.SetColor(Color.Green);
			var colRange2 = WorkSheet.Column(2);
			colRange2.Style.Border.Top.Style = ExcelBorderStyle.None;
			colRange2.Style.Border.Bottom.Style = ExcelBorderStyle.None;
			colRange2.Style.Border.Left.Style = ExcelBorderStyle.None;
			colRange2.Style.Border.Right.Style = ExcelBorderStyle.None;
			pck.Save();
		}
	}

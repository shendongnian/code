	[TestMethod]
	public void Pivot_Table_Conditional_Format()
	{
		//https://stackoverflow.com/questions/59359688/how-to-apply-conditional-formatting-in-pivot-table-epplus
		//Throw in some data
		var dt = new DataTable("tblData");
		dt.Columns.AddRange(new[]
		{
			new DataColumn("Group", typeof (string)),
			new DataColumn("MValue", typeof (int)),
			new DataColumn("Month", typeof (int)),
			new DataColumn("String", typeof (object))
		});
		var rnd = new Random();
		for (var i = 0; i < 100; i++)
		{
			var row = dt.NewRow();
			//This adds some randomness to the number of groups that will be created
			row[0] = $"Group {rnd.Next(1, 100)}";
			row[1] = i * rnd.Next(1, 100);
			
			//This adds randomness to the columns so not guaranteed to be all 12
			row[2] = rnd.Next(1, 12);
			row[3] = Path.GetRandomFileName();
			dt.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Pivot_Table_Conditional_Format.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var wsData = pck.Workbook.Worksheets.Add("Data");
			wsData.Cells.LoadFromDataTable(dt, true);
			var wsPivot = pck.Workbook.Worksheets.Add("Pivot");
			var pivotTable1 = wsPivot.PivotTables.Add(
				wsPivot.Cells["A1"]
				, wsData.Cells[1, 1, wsData.Dimension.End.Row, wsData.Dimension.End.Column]
				, "DataPivot"
			);
			pivotTable1.DataFields.Add(pivotTable1.Fields["MValue"]);
			//Grouping will be by the "Group" column
			pivotTable1.RowFields.Add(pivotTable1.Fields["Group"]);
			//Columns will be months
			pivotTable1.ColumnFields.Add(pivotTable1.Fields["Month"]);
			//Set conditional formatting but have to determine the range in the pivot table
			var groups = dt
				.Rows
				.Cast<DataRow>()
				.Select(row => row["Group"])
				.Distinct()
				.ToList();
			var columns = dt
				.Rows
				.Cast<DataRow>()
				.Select(row => row["Month"])
				.Distinct()
				.ToList();
			var colOffset = pivotTable1.FirstDataCol;
			var groupOffset = pivotTable1.FirstDataRow + pivotTable1.FirstHeaderRow;
			var range = new ExcelAddress
			(
				pivotTable1.Address.Start.Row + groupOffset
				, pivotTable1.Address.Start.Column + colOffset
				, groups.Count + groupOffset
				, columns.Count + colOffset
			);
			var cond = wsPivot.ConditionalFormatting.AddGreaterThanOrEqual(range);
			cond.Formula = "100";
			cond.Style.Font.Color.Color = Color.Black;
			cond.Style.Fill.PatternType = ExcelFillStyle.Solid;
			cond.Style.Fill.BackgroundColor.Color = Color.Yellow;
			//Only way to set the pivot table as the target is with XML Hack
			var parent = cond.Node.ParentNode;
			var doc = parent.OwnerDocument;
			//Need an attribute "pivot" with a value of "1" (true)
			//https://docs.microsoft.com/en-us/dotnet/api/documentformat.openxml.spreadsheet.conditionalformatting.pivot?view=openxml-2.8.1
			var att = doc.CreateAttribute("pivot", doc.NamespaceURI);
			att.Value = "1";
			parent.Attributes.Append(att);
			pck.Save();
		}
	}

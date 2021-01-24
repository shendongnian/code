	[TestMethod]
	public void Chart_Template_Rename_Test()
	{
		//https://stackoverflow.com/questions/57829441/renaming-sheet-with-a-chart-using-epplus
		var templateFileInfo = new FileInfo(@"C:\temp\Chart_Two_Series.xlsx");
		Assert.IsTrue(templateFileInfo.Exists);
		var fileInfo = new FileInfo(@"C:\temp\Chart_Template_Rename_Test.xlsx");
		if (fileInfo.Exists)
			fileInfo.Delete();
		using (var templateFile = new ExcelPackage(templateFileInfo))
		using (var ExcelFile = new ExcelPackage(fileInfo))
		{
			ExcelWorksheet ws;
			var sampleID = "Sample1";
			var origWsName = "Content";
			ExcelWorksheet templateWs = templateFile.Workbook.Worksheets[origWsName];
			ws = ExcelFile.Workbook.Worksheets.Add(origWsName, templateWs);
			ws.Name = string.Format("{0} {1}", "Sample ", sampleID);
			//Look for "top-level" charts
			foreach (var excelDrawing in ws.Drawings)
			{
				if (!(excelDrawing is ExcelChart chart))
					continue;
				//Charts can contain other charts so use plot area to loop through them
				foreach (var chartType in chart.PlotArea.ChartTypes)
				foreach (ExcelChartSerie serie in chartType.Series)
				{
					serie.Series = serie.Series.Replace(origWsName, ws.Name);
					serie.XSeries = serie.XSeries.Replace(origWsName, ws.Name);
					if (serie.HeaderAddress != null)
						serie.HeaderAddress = new ExcelAddressBase(serie
							.HeaderAddress
							.Address
							.Replace(origWsName, ws.Name)
						);
				}
			}
			ExcelFile.Save();
		}
	}

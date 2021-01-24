	[TestMethod]
	public void Chart_Two_Series()
	{
		//https://stackoverflow.com/questions/57500910/how-to-put-two-series-with-different-types-of-charts-inside-a-control-chart-usinvar existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		var fileInfo = new FileInfo(@"c:\temp\Chart_Two_Series.xlsx");
		if (fileInfo.Exists)
			fileInfo.Delete();
		using (var pck = new ExcelPackage(fileInfo))
		{
			var ws = pck.Workbook.Worksheets.Add("Content");
			//Some data
			ws.Cells["C5"].Value = "amarillo";
			ws.Cells["C6"].Value = 12;
			ws.Cells["C7"].Value = 485;
			ws.Cells["D5"].Value = "rojo";
			ws.Cells["D6"].Value = 121;
			ws.Cells["D7"].Value = 77;
			ws.Cells["E5"].Value = "verde";
			ws.Cells["E6"].Value = 548;
			ws.Cells["E7"].Value = 44;
	  
			var myChart = ws.Drawings.AddChart("chart", eChartType.ColumnClustered);
			//Define las series para el cuadro
			var series = myChart.Series.Add("C6:E6", "C5:E5");
			myChart.Border.Fill.Color = System.Drawing.Color.Green;
			myChart.Title.Text = "My Chart";
			myChart.SetSize(500, 400);
			//Agregar a la 6ta fila y a la 6ta columna
			myChart.SetPosition(6, 0, 10, 0);
			//Define las series para el cuadro
			var myChart2 = myChart.PlotArea.ChartTypes.Add(eChartType.Line);
			var series2 = myChart2.Series.Add("C7:E7", "C5:E5");
			ws.Cells["A:AZ"].AutoFitColumns();
			pck.Save();
		}
	}

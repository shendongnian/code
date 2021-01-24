	[TestMethod]
	public void Chart_Rotate_x_Axis()
	{
		//https://stackoverflow.com/questions/55743869/x-axis-label-formatting-issue-while-exporting-chart-to-excel-using-epplus#comment98253473_55743869
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] {
			new DataColumn("Col1", typeof(int)),
			new DataColumn("Col2", typeof(int)),
			new DataColumn("Col3", typeof(object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = i;
			row[1] = i * 10;
			row[2] = Path.GetRandomFileName();
			datatable.Rows.Add(row);
		}
		//Create a test file    
		var fileInfo = new FileInfo(@"c:\temp\Chart_Rotate_x_Axis.xlsx");
		if (fileInfo.Exists)
			fileInfo.Delete();
		using (var pck = new ExcelPackage(fileInfo))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			var chart = worksheet.Drawings.AddChart("chart test", eChartType.XYScatter);
			var series = chart.Series.Add(worksheet.Cells["B2:B11"], worksheet.Cells["A2:A11"]);
			//Get the chart's xml
			var chartXml = chart.ChartXml;
			var chartNsUri = chartXml.DocumentElement.NamespaceURI;
			var mainNsUri = "http://schemas.openxmlformats.org/drawingml/2006/main";
			//XML Namespaces
			var nsm = new XmlNamespaceManager(chartXml.NameTable);
			nsm.AddNamespace("c", chartNsUri);
			nsm.AddNamespace("a", mainNsUri);
			//Get the axis nodes
			var xdoc = worksheet.WorksheetXml;
			var valAxisNodes = chartXml.SelectNodes("c:chartSpace/c:chart/c:plotArea/c:valAx", nsm);
			foreach (XmlNode valAxisNode in valAxisNodes)
			{
				//Axis one should be the X Axis
				if (valAxisNode.SelectSingleNode("c:axId", nsm).Attributes["val"].Value == "1")
				{
					var txPrNode = valAxisNode.SelectSingleNode("c:txPr", nsm) ?? valAxisNode.AppendChild(chartXml.CreateNode(XmlNodeType.Element, "c:txPr", chartNsUri));
					var bodyPrNode = txPrNode.SelectSingleNode("a:bodyPr", nsm) ?? txPrNode.AppendChild(chartXml.CreateNode(XmlNodeType.Element, "a:bodyPr", mainNsUri));
					//Set the rotation angle
					var att = chartXml.CreateAttribute("rot");
					att.Value = "-5400000";
					bodyPrNode.Attributes.Append(att);
					var att2 = chartXml.CreateAttribute("vert");
					att2.Value = "horz";
					bodyPrNode.Attributes.Append(att2);
					txPrNode.AppendChild(chartXml.CreateNode(XmlNodeType.Element, "a:lstStyle", mainNsUri));
					var pNode = chartXml.CreateNode(XmlNodeType.Element, "a:p", mainNsUri);
					txPrNode.AppendChild(pNode);
					var pPrNode = chartXml.CreateNode(XmlNodeType.Element, "a:pPr", mainNsUri);
					pNode.AppendChild(pPrNode);
					var defRPrNode = chartXml.CreateNode(XmlNodeType.Element, "a:defRPr", mainNsUri);
					pPrNode.AppendChild(defRPrNode);
				}
			}
			pck.Save();
		}
	}

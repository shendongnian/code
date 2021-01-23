		System.Web.UI.DataVisualization.Charting.Chart chart = new System.Web.UI.DataVisualization.Charting.Chart();
		Series s2 = new Series("Series1");
		s2.ChartArea = "Area1";
		s2.ChartType = SeriesChartType.Column;
		s2.Points.Add(new DataPoint
		{
			AxisLabel = "Value1",
			YValues = new double[] { 1 }
		});
		s2.Points.Add(new DataPoint
		{
			AxisLabel = "Value2",
			YValues = new double[] { 2 }
		});
		chart.Series.Add(s2);
		ChartArea ca1 = new ChartArea("Area1");
		chart.ChartAreas.Add(ca1);
                
                //REPOSITIONED
		if (config.Length > 0)
		{
			chart.Serializer.IsTemplateMode = true;
			chart.Serializer.IsResetWhenLoading = false;
			chart.Serializer.SerializableContent = "*.*";
			chart.Serializer.Load(config);
		}
		using (var ms = new MemoryStream())
		{
			chart.SaveImage(ms, ChartImageFormat.Png);
			ms.Seek(0, SeekOrigin.Begin);
			return File(ms.ToArray(), "image/png", "mychart.png");
		}
	}

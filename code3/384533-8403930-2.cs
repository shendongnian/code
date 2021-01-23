    public ActionResult Chart()
    {
        Chart chart = new Chart();
        chart.ChartAreas.Add(new ChartArea());
        chart.Series.Add(new Series("Data"));
        chart.Series["Data"].ChartType = SeriesChartType.Pie;
        chart.Series["Data"]["PieLabelStyle"] = "Outside"; 
        chart.Series["Data"]["PieLineColor"] = "Black";
        chart.Series["Data"].Points.DataBindXY(
    	    data.Select(data => data.Name.ToString()).ToArray(), 
            data.Select(data => data.Count).ToArray());
        //Other chart formatting and data source omitted.
        MemoryStream ms = new MemoryStream();
        chart.SaveImage(ms, ChartImageFormat.Png);
        return File(ms.ToArray(), "image/png");
    }

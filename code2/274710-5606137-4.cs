    private void PopulateChart()
    {
        int elements = 100;
    
        // creates 100 random X points
        Random r = new Random();
        List<double> xValues = new List<double>();
        double currentX = 0;
        for (int i = 0; i < elements; i++)
        {
            xValues.Add(currentX);
            currentX = currentX + r.Next(1, 100);
        }
    
        // creates 100 random Y values
        List<double> yValues = new List<double>();
        for (int i = 0; i < elements; i++)
        {
            yValues.Add(r.Next(0, 20));
        }
    
        // remove all previous series
        chart1.Series.Clear();
    
        var series = chart1.Series.Add("MySeries");
        series.ChartType = SeriesChartType.Line;
        series.XValueType = ChartValueType.Auto;
    
        DateTime baseDate = DateTime.Today;
        for (int i = 0; i < xValues.Count; i++)
        {
            var xDate = baseDate.AddSeconds(xValues[i]);
            var yValue = yValues[i];
            series.Points.AddXY(xDate, yValue);
        }
    
        // show an X label every 3 Minute
        chart1.ChartAreas[0].AxisX.Interval = 3.0;
        chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
    
        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
    }

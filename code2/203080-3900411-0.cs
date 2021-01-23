    Chart1.ChartAreas[0].AxisY.Minimum = (new DateTime(2010, 10, 31, 16, 00, 00)).ToOADate();
    Chart1.ChartAreas[0].AxisY.Maximum = (new DateTime(2010, 10, 31, 21, 00, 00)).ToOADate();
    Chart1.ChartAreas[0].AxisY.IsReversed = true;
    Chart1.ChartAreas[0].AxisY.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Minutes;
    Chart1.ChartAreas[0].AxisY.Interval = 15;

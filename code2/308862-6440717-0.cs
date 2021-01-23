    public static System.Web.UI.DataVisualization.Charting.Chart addLineToChart(
        System.Web.UI.DataVisualization.Charting.Chart pChart, double pValue, System.Drawing.Color pColor)
    {        
        // I will declare a new series where every value is the value passed in
        System.Web.UI.DataVisualization.Charting.Series constantLineSeries = new System.Web.UI.DataVisualization.Charting.Series();
        constantLineSeries.ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        constantLineSeries.BorderWidth = ChartingValues.CHART_LINE_THICKNESS;
        constantLineSeries.Color = pColor;
        // At each point in the old series, add a constant point in the new series.
        foreach(System.Web.UI.DataVisualization.Charting.DataPoint point in pChart.Series[0].Points)
        {
            System.Web.UI.DataVisualization.Charting.DataPoint constantLinePoint = new System.Web.UI.DataVisualization.Charting.DataPoint();
            constantLinePoint.XValue = point.XValue;            
            constantLinePoint.YValues = new double[] { pValue };
            constantLineSeries.Points.Add(constantLinePoint);
        }
        pChart.Series.Add(constantLineSeries);
        pChart.ChartAreas[0].Area3DStyle.Enable3D = false;
        return pChart;
    }

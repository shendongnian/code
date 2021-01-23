    private void OnChartMouseMove(object sender, MouseEventArgs e)
    {
        var sourceChart = sender as Chart;
        HitTestResult result = sourceChart.HitTest(e.X, e.Y);
        ChartArea chartAreas = sourceChart.ChartAreas[0];
        if (result.ChartElementType == ChartElementType.DataPoint)	
        {
            chartAreas.CursorX.Position = chartAreas.AxisX.PixelPositionToValue(e.X);
            chartAreas.CursorY.Position = chartAreas.AxisY.PixelPositionToValue(e.Y);
        }
    }

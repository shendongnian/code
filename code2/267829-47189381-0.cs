    private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
    {
        // If the mouse isn't on the plotting area, a datapoint, or gridline then exit
        HitTestResult htr = chart.HitTest(e.X, e.Y);
        if (htr.ChartElementType != ChartElementType.PlottingArea && htr.ChartElementType != ChartElementType.DataPoint && htr.ChartElementType != ChartElementType.Gridlines)
            return;
    
        ChartArea ca = chart.ChartAreas[0]; // Assuming you only have 1 chart area on the chart
    
        double xCoord = ca.AxisX.PixelPositionToValue(e.X);
        double yCoord = ca.AxisY.PixelPositionToValue(e.Y);
    
        e.Text = "X = " + Math.Round(xCoord, 2).ToString() + "\nY = " + Math.Round(yCoord, 2).ToString();
    }

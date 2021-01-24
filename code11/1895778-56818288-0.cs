private void Chart1_MouseClick(object sender, MouseEventArgs e) {
    double yValue = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
    yValue = Math.Round(yValue, 0);
}
Or perhaps you wish to find DataPoints near the cursor click position?
private void Chart1_MouseClick(object sender, MouseEventArgs e) {
    HitTestResult result = chart1.HitTest(e.X, e.Y);
    if (result.ChartElementType == ChartElementType.DataPoint) {
        DataPoint point = (DataPoint)result.Object;
        double yValue = point.YValues[0];
    }
}

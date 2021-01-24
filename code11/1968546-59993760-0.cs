c#
private SKMatrix ChartToDeviceMatrix, DeviceToChartMatrix;
private void ConfigureTransforms(SKPoint ChartMin, SKPoint ChartMax, SKPoint DeviceMin, SKPoint DeviceMax)
{
    this.ChartToDeviceMatrix = SKMatrix.MakeIdentity();
    float xScale = (DeviceMax.X - DeviceMin.X) / (ChartMax.X - ChartMin.X);
    float yScale = (DeviceMin.Y - DeviceMax.Y) / (ChartMax.Y - ChartMin.Y);
    this.ChartToDeviceMatrix.SetScaleTranslate(xScale, yScale, -ChartMin.X * xScale + DeviceMin.Y, -ChartMin.Y * yScale + DeviceMax.Y);
    this.ChartToDeviceMatrix.TryInvert(out this.DeviceToChartMatrix);
}

    private struct PointD
    {
      public double X;
      public double Y;
      public PointD(double X, double Y)
      {
        this.X = X;
        this.Y = Y;
      }
    }
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
      var pos = LocationInChart(e.X, e.Y);
      lblCoords.Text = string.Format("({0}, {1}) ... ({2}, {3})", e.X, e.Y, pos.X, pos.Y);
    }
    private PointD LocationInChart(double xMouse, double yMouse)
    {
      var ca = chart1.ChartAreas[0];
      //Position inside the control, from 0 to 100
      var relPosInControl = new PointD
      (
        ((double)xMouse / (double)execDetailsChart.Width) * 100,
        ((double)yMouse / (double)execDetailsChart.Height) * 100
      );
      //Verify we are inside the Chart Area
      if (relPosInControl.X < ca.Position.X || relPosInControl.X > ca.Position.Right
      || relPosInControl.Y < ca.Position.Y || relPosInControl.Y > ca.Position.Bottom) return new PointD(double.NaN, double.NaN);
      
      //Position inside the Chart Area, from 0 to 100
      var relPosInChartArea = new PointD
      (
        ((relPosInControl.X - ca.Position.X) / ca.Position.Width) * 100,
        ((relPosInControl.Y - ca.Position.Y) / ca.Position.Height) * 100
      );
      //Verify we are inside the Plot Area
      if (relPosInChartArea.X < ca.InnerPlotPosition.X || relPosInChartArea.X > ca.InnerPlotPosition.Right
      || relPosInChartArea.Y < ca.InnerPlotPosition.Y || relPosInChartArea.Y > ca.InnerPlotPosition.Bottom) return new PointD(double.NaN, double.NaN);
      //Position inside the Plot Area, 0 to 1
      var relPosInPlotArea = new PointD
      (
        ((relPosInChartArea.X - ca.InnerPlotPosition.X) / ca.InnerPlotPosition.Width),
        ((relPosInChartArea.Y - ca.InnerPlotPosition.Y) / ca.InnerPlotPosition.Height)
      );
      var X = relPosInChartArea.X * (ca.AxisX.Maximum - ca.AxisX.Minimum) + ca.AxisX.Minimum;
      var Y = (1 - relPosInChartArea.Y) * (ca.AxisY.Maximum - ca.AxisY.Minimum) + ca.AxisY.Minimum;
      return new PointD(X, Y);
    }

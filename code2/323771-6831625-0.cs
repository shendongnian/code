    try
    {
      var pos = e.Location;
      var results = kpiChartControl.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
      foreach (var result in results)
      {
        if (result.ChartElementType == ChartElementType.DataPoint)
        {
          if (result.Series.Points[result.PointIndex].AxisLabel == "Live")
          {
            Console.WriteLine("success?");
          }
        }
      }  
    }

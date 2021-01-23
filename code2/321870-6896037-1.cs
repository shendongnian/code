    var pos = e.Location;
    var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
    foreach (var result in results)
    {
      if (result.ChartElementType == ChartElementType.DataPoint)
      {
        if (result.Series.Points[result.PointIndex].Color == Color.Red)
        {
           Console.WriteLine("success?");
        }
      }
    }  

    Series oldSeries = myChart.Series[0];
    Series newSeries = new Series();
    DataPointCollection newPoints = new DataPointCollection();
    double newXValue, newYValue;
    for (int i = 0; i < oldSeries.Points.Count; i++)
    {
      //... add old points here
      newPoints.AddXY(oldSeries.Points[i].XValue, oldSeries.Points[i].YValues[0]);
      if (oldSeries.Points[i] ...) //your condition here
      {
        //your logic for the new point
        newXValue = 100;
        newYValue = 100;
        newPoints.AddXY(newXValue, newYValue);
      }
    }
    myChart.Series.Clear();
    myChart.Series.Add(newSeries);

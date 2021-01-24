    if (ColumnChart != null)
    {
       if (ColumnChart.ColumnSeries.Count > 0)
       {
          (ColumnChart.ColumnSeries[0] as ColumnSeries).ItemsSource = listOfAverage;
       }
       else
       {
          LogWarning("ColumnChart.ColumnSeries[0] does not contain any elements");
       }
    }
    else
    {
       LogWarning("ColumnChart object is null");
    }

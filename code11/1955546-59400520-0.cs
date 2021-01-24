    public class ChartDataModel
    {
      public ChartDataModel()
      {
        this.BlueSeries = new ColumnSeries()
        {
          Title = "Population of Bodrum",
          Values = new ChartValues<double> { 1500, 2500, 3700, 2000, 1000 },
          Fill = Brushes.Blue
        };
        this.RedSeries = new ColumnSeries()
        {
          Title = string.Empty,
          Values = new ChartValues<double>(),
          Fill = Brushes.Red
        };
        this.SeriesCollection = new SeriesCollection() { this.BlueSeries, this.RedSeries };
      }
      
      private void ChangeThirdChartPointColorToRed()
      {
        // Get the third blue point and remove it from the blue series
        ChartPoint chartPointToChangeColor = this.BlueSeries.Values.GetPoints(this.BlueSeries).ElementAt(2);
        this.BlueSeries.Values.RemoveAt(2);
        // Add dummy values to shift the red point to the relevant x position
        for (var count = 0; count < chartPointToChangeColor.X; count++)
        {
          this.RedSeries.Values.Add(0.0);
        }
        // Add the previously removed point value to the red series
        this.RedSeries.Values.Add(chartPointToChangeColor.Y);
      }
      // The actual chart data source
      public SeriesCollection SeriesCollection { get; set; }
      private ColumnSeries BlueSeries { get; set; }
      private ColumnSeries RedSeries { get; set; }
    }

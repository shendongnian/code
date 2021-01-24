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
        this.SeriesCollection = new SeriesCollection() { this.BlueSeries };
      }
      
      private void ChangeThirdChartPointColorToRed()
      {
        CartesianMapper<double> mapper = Mappers.Xy<double>()
          .X((value, index) => index)
          .Y(value => value)
          .Fill((value, index) => index == 2 ? Brushes.Red : Brushes.Blue);
        // Dynamically set the third chart point color to red
        this.BlueSeries.Configuration = mapper;
      }
      // The actual chart data source
      public SeriesCollection SeriesCollection { get; set; }
      private ColumnSeries BlueSeries { get; set; }
    }

    public class ChartModel
    {
      public ChartModel()
      {
        CartesianMapper<DateTimePoint> mapper = Mappers.Xy<DateTimePoint>()
          .X((item) => (double) item.Timestamp.Ticks / TimeSpan.FromMinutes(5).Ticks) // Set interval to 5 minutes
          .Y(item => item.Value)
          .Fill((item) => item.Value > 99 ? Brushes.Red : Brushes.Blue);
        var series = new ColumnSeries()
        {
          Title = "Timestamp Values",
          Configuration = mapper,
          Values = new ChartValues<DateTimePoint>
          {
            new DateTimePoint() {Timestamp = DateTime.Now, Value = 100},
            new DateTimePoint() {Timestamp = DateTime.Now.AddMinutes(15), Value = 78},
            new DateTimePoint() {Timestamp = DateTime.Now.AddMinutes(30), Value = 21}
          }
        };
        this.SeriesCollection = new SeriesCollection() { series };
      }
      public SeriesCollection SeriesCollection { get; set; }
      public Func<double, string> LabelFormatter =>
        value => new DateTime((long) value * TimeSpan.FromMinutes(5).Ticks).ToString("t");
    }

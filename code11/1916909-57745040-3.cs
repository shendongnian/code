    public class FruitPieChartDataModel
    {
      public FruitPieChartDataModel(Fruit entityFrameworkDataModel)
      {
        this.AppleDataSeries = new ChartValues<double>() { entityFrameworkDataModel.Apples };
        this.OrangeDataSeries = new ChartValues<double>() { entityFrameworkDataModel.Oranges };
        this.GrapeDataSeries = new ChartValues<double>() { entityFrameworkDataModel.Grapes };
        this.BananaDataSeries = new ChartValues<double>() { entityFrameworkDataModel.Bananas };
      }
      public ChartValues<double> AppleDataSeries { get; set; }
      public ChartValues<double> OrangeDataSeries { get; set; }
      public ChartValues<double> GrapeDataSeries { get; set; }
      public ChartValues<double> BananaDataSeries { get; set; }
    }

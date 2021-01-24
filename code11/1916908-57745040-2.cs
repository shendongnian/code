    public partial class Fruit
    {
      public ChartValues<double> Apples { get; set; } = new ChartValues<double>() { 2 };
      public ChartValues<double> Oranges { get; set; } = new ChartValues<double>() { 3 };
      public ChartValues<double> Grapes { get; set; } = new ChartValues<double>() { 1 };
      public ChartValues<double> Bananas { get; set; } = new ChartValues<double>() { 2 };
    }
    public partial class PieChartExample : UserControl
    {   
      public Fruit Fruit => new Fruit();
    
      ...
    }

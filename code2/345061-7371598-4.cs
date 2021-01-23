    public partial PieChartControl: UserControl
    {
       // other methods ...
       public void SetDataSource(object src)
       {
          // set the series type to Pie etc... 
          this.chart.DataSource = src;
       }
    }

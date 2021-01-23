    // the form having the pie chart control
    public partial class Form1: Form
    {
       // other methods ...
    
       public void SetDataSource(object src)
       {
          this.PieChartControl.SetDataSource(src);
       }
    }

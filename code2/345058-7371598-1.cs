    // the form having the 2 controls
    public partial class Form3: Form
    {
       // other methods ...
       
       public ChartClicked ChartClicked { get; private set; }
       
       public Form3()
       {
          this.InitializeComponents();
          this.PieChartControl.Click += chartControlClicked;
          this.BarChartControl.Click += chartControlClicked;
       } 
    
       public void SetDataSource(object src)
       {
          this.PieChartControl.SetDataSource(src);
          this.BarChartControl.SetDataSource(src);
       }
      
       private void chartControlClicked(object sender, EventArgs e)
       { 
          if(sender == this.PieChartControl)
              this.ChartClicked = ChartClicked .Pie;
          else if(sender == this.BarChartControl)
              this.ChartClicked = ChartClicked .Bar;
          this.Close();
       }
    }

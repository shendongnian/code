    public class YourPage: ChartProperties
    {
       protected override int StartBalance
       {
         get {return int.Parse(txtStartBalance.Text);} 
       }
       
       //All properties
       ..
       
       private void BindChartData()
       {
          RepeatedCallParameter p  = PrepareRepeatedCallParameters();
          Chart.DataSource = DB.RepeatedCall(p);
          Chart.DataBind();   
       }
    }

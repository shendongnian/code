    public class YourPage: ChartProperties
    {
       protected int StartBalance
       {
         return int.Parse(txtStartBalance.Text);
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

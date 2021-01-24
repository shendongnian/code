TimeSpan total = new TimeSpan();
protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      
        var ts = DataBinder.Eval(e.Row.DataItem, "Amount").ToString(); 
        var t = DateTime.Parse(ts).TimeOfDay;
        totalTime += t;
    }

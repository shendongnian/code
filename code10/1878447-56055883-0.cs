string totalTime;
TimeSpan ts = new TimeSpan();
protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        ts = ts.Add(TimeSpan.Parse((DataBinder.Eval(e.Row.DataItem, "Amount")));
        var hourPart = ((int)(Math.Truncate(ts.TotalMinutes/60))).ToString().PadLeft(2,'0');
        var minutePart = (ts.TotalMinutes%60).ToString().PadLeft(2,'0');
        totalTime = hourPart+":"+minutePart;
    }
}

    protected void MyGrid_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onClick"] = string.Format(
                "window.location = 'ResponseMetric.aspx?MsgID={0}';",
                DataBinder.Eval(e.Row.DataItem, "MsgID"));
        }
    }

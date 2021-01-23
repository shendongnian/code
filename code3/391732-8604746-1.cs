    protected void MyGrid_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        // only datarows, no header rows:
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // user e.Row.DataItem to get to the data
            if(your logic here about groups)
            {
                 e.Row.Style = "border-bottom:solid black 1px";
            }
        }
    }

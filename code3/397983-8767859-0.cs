    protected void detailsView_RowDataBound(object sender, 
    GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(...)//some condition for selection of row to be higlighted
            {
               e.Row.BackColor = System.Drawing.Color.Red;
            }
        }
    }

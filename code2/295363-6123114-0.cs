     protected void grdForecast_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType ==DataControlRowType.DataRow )
        {
            ((Button)e.Row.FindControl("buttonId")).Attributes.Add("onclick", "javascript:update(" + (e.Row.RowIndex ) + ");");
        }
    }

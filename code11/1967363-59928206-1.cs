    protected void summaryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if(your condition)
            {
                e.Row.Cells[0].Text = "T";
            }
        }
    }

    protected void sampleGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            LinkButton headerText = e.Row.Cells[0].Controls[0] as LinkButton; 
            headerText.Text = "Michel";
        }
    }

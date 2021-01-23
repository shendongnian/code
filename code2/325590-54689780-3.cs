    protected void mainGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblName = (Label)e.Row.FindControl("lblName");
            LinkButton btnLink = (LinkButton)e.Row.FindControl("btnLink");
            HtmlAnchor btnAnchor = (HtmlAnchor)e.Row.FindControl("btnAnchor");
            HtmlInputControl hdnBtnInput = (HtmlInputControl)e.Row.FindControl("hdnBtnInput");
        }
    }

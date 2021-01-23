    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) {
            LinkButton HLink = (LinkButton)e.Row.Cells[0].Controls[0];
            HLink.Text = "Last Name";
        }
    }

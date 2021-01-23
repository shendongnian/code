    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) {
            GridView1.Columns[0].HeaderText = "Last Name";
        }
    }

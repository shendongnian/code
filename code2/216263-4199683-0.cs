    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Label3 = (Label)e.Row.FindControl("Label3");
            ....
        }
    }

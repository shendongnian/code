    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox cb = (CheckBox)e.Row.FindControl("checkbox");
            Label lbl = (Label)e.Row.FindControl("test-label");
            lbl.Visible = !(cb.Checked);
        }
    }

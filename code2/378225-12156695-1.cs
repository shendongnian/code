    protected void GvManualShows_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //label lbl = (label)e.Row.FindControl("lblHidden");
            if (e.Row.Cells[14].Text == "Y")
            {
                // CheckBox cb = (CheckBox)e.Row.FindControl("chk");
                CheckBox chk = (CheckBox)e.Row.Cells[0].FindControl("chkBox");
                chk.Checked = true;
            }
        }
    }

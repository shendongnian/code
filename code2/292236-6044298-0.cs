    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            ((CheckBox)row.FindControl("FirstCheckBox")).Checked = true;
            ((CheckBox)row.FindControl("SecondCheckBox")).Checked = true;
            GridView1.UpdateRow(row.RowIndex,true);
        }
    }

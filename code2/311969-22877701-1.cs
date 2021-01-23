    protected void rbSelector_CheckedChanged(object sender, System.EventArgs e)
    {
        foreach (GridViewRow oldrow in GridView2.Rows)
        {
            ((RadioButton)oldrow.FindControl("RadioButton1")).Checked = false;
        }
        //Set the new selected row
        RadioButton rb = (RadioButton)sender;
        GridViewRow row = (GridViewRow)rb.NamingContainer;
        ((RadioButton)row.FindControl("RadioButton1")).Checked = true;
    }

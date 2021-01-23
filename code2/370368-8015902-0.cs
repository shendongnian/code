    protected void chkDynamic_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked)
            Response.Write( "you checked the checkbox");
        else 
            Response.Write("checkbox is not checked");
    }

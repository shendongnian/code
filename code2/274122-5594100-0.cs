    protected void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
    {
    	CheckBox checkbox = (CheckBox)sender;
    	GridViewRow row = (GridViewRow)checkbox.NamingContainer;
    	if (checkbox.Checked == true) {
    		row.BackColor = System.Drawing.Color.Red;
    		mygridview.Columns(0).Visible = false;
    	}
    }

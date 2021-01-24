    protected void ddlJM3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJM3.SelectedItem.Text.ToLower() == "a1")
        {
            lblMsgJM.Text = "+1";
        }
        if (ddlJM3.SelectedItem.Text.ToLower() == "a2")
        {
            lblMsgJM.Text = "+2";
        }
    
        if (ddlJM3.SelectedItem.Text.ToLower() == "b1")
        {
            lblMsgJM.Text = "-1";
        }
        if (ddlJM3.SelectedItem.Text.ToLower() == "b2")
        {
            lblMsgJM.Text = "-2";
        }
    }

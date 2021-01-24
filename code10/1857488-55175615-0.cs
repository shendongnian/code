    protected void ddlJM3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJM3.SelectedValue == "A1")
        {
            lblMsgJM.Text = "+1";
        }
        if (ddlJM3.SelectedValue == "A2")
        {
            lblMsgJM.Text = "+2";
        }
    
        if (ddlJM3.SelectedValue == "B1")
        {
            lblMsgJM.Text = "-1";
        }
        if (ddlJM3.SelectedValue == "B2")
        {
            lblMsgJM.Text = "-2";
        }
    }

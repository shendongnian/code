    protected bool SetVisibility(object Desc, int length)
    {
        return Desc.ToString().Length > length;
    }
    
    protected void ReadMoreLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton button = (LinkButton)sender;
        GridViewRow row = button.NamingContainer as GridViewRow;
        Label descLabel = row.FindControl("lblDescription") as Label;
        button.Text = (button.Text == "Read More") ? "Hide" : "Read More";
        string temp = descLabel.Text;
        descLabel.Text = descLabel.ToolTip;
        descLabel.ToolTip = temp;
    }

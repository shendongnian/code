    protected bool SetVisibility(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return false; }
        return description.Length > maxLength;
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
    protected string Limit(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return description; }
        return description.Length <= maxLength ? 
            description : description.Substring(0, maxLength)+ "...";
    }

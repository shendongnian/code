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
    //including the original helper from the question with changes in signature
    protected string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());
    
        if (strDesc.Length > length)
            return strDesc.ToString().Substring(0, length) + "...";
        else return strDesc.ToString();
    }

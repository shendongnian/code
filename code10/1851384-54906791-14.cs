    protected void button1_Click(object sender, EventArgs e)
    {
        var selectedNames = ddlstatus.Items.Cast<ListItem>()
                             .Where(i => i.Selected)
                             .Select(i => i.Value)
                             .ToList();
    
        string selectedValue = string.Join(",", selectedNames);
    
        ViewState["stat"] = selectedValue;
    }
    

    protected void chkBxList_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool oneSelected = false;
        foreach (ListItem item in chkBxList.Items)
        {
            if (item.Selected)
                oneSelected = true;
        }
        if (!oneSelected)
            lblError.Text = "Please select an option from the checkbox list.";
        else
            lblError.Text = "At least one checkbox is selected";
    }
    

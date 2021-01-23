    protected void myRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
    
        int selectedIndex = e.Item.ItemIndex;
        foreach(RepeaterItem item in myRepeater.Items)
        {
            ((LinkButton)item.FindControl("lnk1")).Visible = (item.ItemIndex != selectedIndex);
            ((Label)item.FindControl("label1")).Visible = (item.ItemIndex == selectedIndex);
        }
    }

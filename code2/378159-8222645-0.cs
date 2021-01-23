    protected void dlData_EditCommand(object source, DataListCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label hf1 = (Label)e.Item.FindControl("hf1");
        }
    }

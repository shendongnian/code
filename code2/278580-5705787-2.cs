    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (ListItem itm in UserGroup.Items)
        {
            if (itm.Selected == true)
            {
                selectionList.Add(Convert.ToInt32(itm.Value));
            }
        }
    }

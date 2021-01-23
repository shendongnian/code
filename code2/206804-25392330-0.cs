    private void BindToolTip(ListControl list)
    {
        foreach (ListItem item in list.Items)
        {
            item.Attributes.Add("title", item.Text);
        }
    }

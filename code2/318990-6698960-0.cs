    foreach (ListItem item in ddlApplicationTerm.Items)
    {
        if (!Status == item.Text)
        {
            ddlApplicationTerm.Items.Add(new ListItem(status));
        }
    }

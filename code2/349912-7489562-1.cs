    string value = this.RolesFilterList.SelectedValue;
    int count = this.UserRolesList.Items.Count - 1;
    
    for(var i=count;i>=0;i--)
    {
        ListItem item = this.UserRolesList.Items[i];
        if (!item.Value.StartsWith(value))
        {
            this.UserRolesList.Items.RemoveAt(i);
        }
    }

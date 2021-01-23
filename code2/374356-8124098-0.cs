    protected void Page_PreRender(object sender, EventArgs e)
    {
        foreach (ListItem item in ckl_EditRole.Items)
        {
            item.Attributes["title"] = GetRoleTooltip(item.Value);
        }
    }
    
    private static string GetRoleTooltip(string p)
    {
        // here is your code to get appropriate tooltip message depending on role
    }

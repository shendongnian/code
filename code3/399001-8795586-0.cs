    private void ApplyFilterExpression()
    {
        var sbFilter = new System.Text.StringBuilder(200);
    
        if (ddlTypes.SelectedIndex != 0)
        {
            sbFilter.Append("type='").Append(ddlTypes.SelectedValue).Append("'");
        }
    
        if (ddlUsers.SelectedIndex != 0)
        {
            if (sbFilter.Length != 0)
            {
                sbFilter.Append(" AND ");
            }
            sbFilter.Append("username='").Append(ddlUsers.SelectedValue).Append("'");
        }
        if (sbFilter.Length != 0)
        {
            dsLogs.FilterExpression = sbFilter.ToString();
        } else
        {
            dsLogs.FilterExpression = null;
        }
    }

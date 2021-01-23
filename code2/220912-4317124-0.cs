    public long? Value
    {
        get { return Int64.Parse(ddlAggerationUnitId.SelectedItem.Value); }
        set
        {
            ListItem item = null;
            if (value.HasValue && ddlAggerationUnitId.Items.Count > 0 && ddlAggerationUnitId.SelectedIndex > 1)
                item = ddlAggerationUnitId.Items.FindByValue(value.ToString());
            if ( item != null)
            {
                ddlAggerationUnitId.SelectedValue = value.ToString();
            }
        }
    }

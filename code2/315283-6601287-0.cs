    public string change_ddlArea
    {
        get { return ddlArea.SelectedItem.Value; }
        set { ddlArea.Items.FindByValue(value).Selected = true; }
    }

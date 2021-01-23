    public string SelectedValuesString
    {
        get
        {
            return String.Join(",",this.Items.Cast<ListItem>().Where(i => i.Selected).Select(i=>i.Value));
        }
    }

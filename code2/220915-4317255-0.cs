    public long? Value
    {
    get { return Int64.Parse(ddlAggerationUnitId.SelectedItem.Value); }
    set
    {
     try 
     {
        if (ddlAggerationUnitId.Items.FindByValue(value.ToString()) != null)
        {
            ddlAggerationUnitId.SelectedValue = value.ToString();
        }
     }
     catch 
     {
     ddlAggerationUnitId.SelectedValue = -1;
     }
    }
    }

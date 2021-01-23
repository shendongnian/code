    protected void DropDownDataBinding(object sender, EventArgs e) //Method to set the selected value on Category dropdown inside repeater
    {
        DropDownList sel = (DropDownList)sender;
        sel.Value = sel.Attributes["SetValue"];
        ListItem li = new ListItem("<< Select >>", "");
        sel.Items.Insert(0,li);
    }
    
    protected DataSet PhysicianSource()
    {
            DataSet ds = new DataSet();
    DataTable dt = ds.Tables.Add("Source");
    dt.Columns.Add("ID", Type.GetType("System.String"));
    dt.Columns.Add("Desc", Type.GetType("System.String"));
    Provider oProvider = new Provider();
    List<ProviderLabel> lstprovider = oProvider.RetrievePhysicianList();
    foreach (ProviderLabel item in lstprovider)
    {
        DataRow dr = dt.NewRow();
        dr[0] = item.ProviderCode.ID.ToString();
        dr[1] = item.Name.ToString();
        dt.Rows.Add(dr);
    }
    return ds;
    }

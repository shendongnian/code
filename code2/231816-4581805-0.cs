    void loadDropDown(ComboBox cb, Object Source, string textField, string valueField)
    {
       cb.DataSource = Source;
       cb.DataTextField = textField;
       cb.DataValueField = valueField;
       cb.DataBind();
    }
    //loadRegions
    loadDropDown(ddlRegion,  new Region().GetRegionID(ddlCountry.SelectedValue), "regionName", "regionID");
    
    //etc for the other dropdown lists

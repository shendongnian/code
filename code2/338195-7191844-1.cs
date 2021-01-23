    Control ddlCtrl = e.Row.FindControl("ddlCities");
    if (ddlCtrl != null)
    {
        DropDownList ddlCities = ddlCtrl as DropDownList;
     
        //using a datasource control
        CitiesDataSourceControl.DataBind();
        if (ddlCities.Items.Count > 0) 
        {
            ListItem item = ddlCities.Items.FindByValue("Boston");
            if (item != null)
                item.Selected = true;
        }
    }
    
    

    try
    {
    	SPSite ohportal = new SPSite("http://moss2007dev:1234");
    	SPWeb site = ohportal.OpenWeb();
    	SPList vitality = site.Lists[properties.ListId];
    	SPList employees = site.Lists["Employees List"];
    	SPListItemCollection vitalityCollection = vitality.Items;
    	SPListItemCollection employeesCollection = employees.Items;
    
    	SPListItem currentItem = properties.ListItem;
    
    	// lookup the employees name
    	string empId = currentItem["EMP_ID"].ToString();
    	SPListItem employee = list.GetItemById(Int32.Parse(empId));
    	properties.AfterProperties["Name"] = employee["Name"].ToString();
    }
    catch (Exception err)
    {
    	properties.ErrorMessage = "ERROR: " + err.Message;
    }

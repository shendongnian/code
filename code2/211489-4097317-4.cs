    try
    {
    	// same code...
    
    	SPListItem currentItem = properties.ListItem;
    
    	// **CHANGED** get the current employee's ID from the current SPListItem
    	string empId = currentItem["Emp ID Field"].ToString();
    	foreach(SPListItem item in employeesCollection)
    	{
    		if(item["EMP_ID"].Equals(empId)){
    			string name = item["Name"].ToString();
    			currentItem["Name"] = name;
    		}
    	}
    }
    catch (Exception err)
    {
    	properties.ErrorMessage = "ERROR: " + err.Message;
    }

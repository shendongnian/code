    // Build a query.
    SPQuery query = new SPQuery();
    query.Query = string.Concat(
    					"<Where><Eq>",
    						"<FieldRef Name='Status'/>",
    						"<Value Type='CHOICE'>Not Started</Value>",
    					"</Eq></Where>",
    					"<OrderBy>",
    						"<FieldRef Name='DueDate' Ascending='TRUE' />",
    						"<FieldRef Name=’Priority’ Ascending='TRUE' />", 
    					"</OrderBy>");                    
    
    query.ViewFields = string.Concat(
    						  "<FieldRef Name='AssignedTo' />",
    						  "<FieldRef Name='LinkTitle' />",
    						  "<FieldRef Name='DueDate' />",
    						  "<FieldRef Name='Priority' />");
    
    query.ViewFieldsOnly = true; // Fetch only the data that we need.
    
    // Get data from a list.
    string listUrl = web.ServerRelativeUrl + "/lists/tasks";
    SPList list = web.GetList(listUrl);
    SPListItemCollection items = list.GetItems(query);

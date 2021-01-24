    ListItemCollection lic = new ListItemCollection();
    lic.Add(new ListItem("first", "1"));
    lic.Add(new ListItem("second", "2", false));
    lic.Add(new ListItem("third", "3"));
    
    foreach(ListItem li in lic)
    {
    	//create a new list item, because otherwise it will skip disabled items.
    	ddl.Items.Add(new ListItem(li.Text, li.Value));
    	if(li.Enabled == false)
    	{
    		ddl.Items[ddl.Items.Count - 1].Attributes.Add("disabled", "");
    	}
    }

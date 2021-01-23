    if (id == locationID)
    {
        ddl.Items.Add(new ListItem(padding + text, id));
    }
    else
    {
        int index =  ddl.Items.IndexOf(ddl.Items.FindByValue(rs.GetString(4).ToString().ToLower()));
        
        //Check to see if this item exists before trying to insert
        if (index == -1) 
        {
            //Add the item if it doesn't exist
            ddl.Items.Add(new ListItem(padding + text, id));
        }
        else
        {
            ddl.Items.Insert(index, new ListItem(padding + text, id));
        }
    }

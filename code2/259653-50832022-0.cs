    ListItemCollection liCol = ddlcustomertype.Items;
    for (int i = 0; i < liCol.Count;i++ )
    {
    	ListItem li = liCol[i];
    	if (li.Value != "1" || li.Value != "3")
    		ddlcustomertype.Items.Remove(li);
    }

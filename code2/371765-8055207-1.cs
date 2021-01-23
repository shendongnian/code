    List<ListItem> listSelected = new List<ListItem>();
    foreach( ListItem li in lst_allmembers.Items )
    {
        if( li.Selected )
            listSelected.Add(li);
    }
    
    foreach( ListItem li in listSelected )
    {
        lst_grpmembers.Items.Add(li.Text, li.Value);
        lst_allmembers.Items.Remove(li);
    }

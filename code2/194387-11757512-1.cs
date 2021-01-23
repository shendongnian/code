    //Listbox cannot be disabled directly, instead the inners should be disabled instead.
    foreach(ListItem item in lbCategory.Items)
    {
        item.Attributes.Add("disabled", "disabled");
    
        if (item.Selected)
        {
            //cannot reliably style with [disabled='disabled'][selected='selected'] or :checked:selected etc, so need a class
            item.Attributes.Add("class", "disabledSelected"); 
        }
    }

    //Listbox cannot be disabled directly, instead the inners should be disabled instead.
                foreach(ListItem item in lstProduct.Items)
                {
                    item.Attributes.Add("disabled", "disabled");
    
                    if (item.Selected)
                    {
                        item.Attributes.Add("class", "disabledSelected"); //cannot reliably style with [disabled='disabled'][selected='selected'] or :checked:selected etc, so need a class.
                    }
                }

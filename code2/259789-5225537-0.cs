    void dataGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item)
            {
                var item = e.Item.DataItem;  // <- entity object that's bound, like person
                var itemIndex = e.Item.ItemIndex; // <- index
            }
            
        }

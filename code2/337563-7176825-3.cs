    void lstviewcategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstviewcategories.SelectedItems.Count > 0)
        {
            CustomListViewItem customListItem = (CustomListViewItem)lstviewcategories.SelectedItems[0];
            switch (customListItem.Type)
            { 
                case CustomListViewItemType.Type1:
                    {
                        //...
                    }break;
                case CustomListViewItemType.Type2:
                    {
                        //...
                    }break;
            }
        }
    }

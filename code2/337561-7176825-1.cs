    void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            CustomListViewItem customListItem = (CustomListViewItem)listView1.SelectedItems[0];
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

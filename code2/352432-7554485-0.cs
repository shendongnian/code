    private void listView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            MyType data = (MyType)((ListViewDataItem)e.Item).DataItem;
    
            // Use your data...
        }
    }

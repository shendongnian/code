    List<ListViewItem> itemsToRemove = new List<ListViewItem>();
    foreach(ListViewItem item in listViewEx1.Items)
    {
       if(!nicks.Contains(item.Text))
          itemsToRemove.Add(item.Text);
    }
    
    foreach(ListViewItem item in itemsToRemove)
       listViewEx1.Items.Remove(item);

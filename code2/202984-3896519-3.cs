    List<ListViewItem> ListViewItems = new List<ListViewItem>();
    foreach (int index in listView1.SelectedIndices)
    {
        ListViewItem SelectedListViewItem = listView1.Items[index];//Exception
        ListViewItems.RemoveAt(index);
    }
    .
    .
    .
    .
    void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
        e.Item = ListViewItems[e.ItemIndex];
    }

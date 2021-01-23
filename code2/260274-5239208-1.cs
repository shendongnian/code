    // This assumes all lists have the sample number of items
    for (int i = 0; i < list1.Count; i++)
    {
        ListViewItem lvi = new ListViewItem(list1[i]);
        lvi.SubItems.Add(list2[i]);
        lvi.SubItems.Add(list3[i]);
        listViewEvents.Items.Add(lvi);
    }
     

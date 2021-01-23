    // I assume you got list of raw dll sizes somewhere
    dllSizes.Sort();
    List<ListViewItem> dllSizesForDisplay = new List<ListViewItem>();
    foreach (var dll in dllSizes)
    {
        dllSizes.Add(new ListViewItem(GetSize(dll.Bytes)));
    }
    // reasign items
    listView.Items.Clear();
    listView.Items.AddRange(dllSizesForDisplay);
    
    

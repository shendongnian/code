    ListView sourceListView = new ListView();
    ListView destListView = new ListView();
    var selected = sourceListView.Items
                                  .Cast<ListViewItem>()
                                  .Where(x => x.Selected)
                                  .ToList();
    foreach (var item in selected)
    {
        sourceListView.Items.Remove(item);
        destListView.Items.Add(item);
    }

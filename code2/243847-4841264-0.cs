    if (listView.SelectedItems.Count > 0)
    {
        var titles = from x in listView.SelectedItems.Cast<ListViewItem>()
                     select x.SubItems[titleColumn.Index].Text;
    
        string firstTitle = titles.First();
        bool allSameTitle = titles.All(t => t == firstTitle);
    }

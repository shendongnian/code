    if (listView.SelectedItems.Count > 0)
    {
        string firstTitle = listView.SelectedItems[0].SubItems[titleColumn.Index].Text;
    
        Predicate<object> sameTitle = delegate(object obj)
        {
            if (!(obj is ListViewItem))
            {
                return false;
            }
    
            return ((ListViewItem)obj).SubItems[titleColumn.Index].Text == firstTitle;
        };
    
        bool allSameTitle = All(listView.SelectedItems, sameTitle);
    }

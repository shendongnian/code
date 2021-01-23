    private DateTime lastScrollTime;
    
    ...
    
    listView.Scrolled += delegate { lastScrollTime = DateTime.Now };
    
    ...
    
    private void AddListItem(DateTime timestamp, string message, int index)
    {
        var listItem = new ListViewItem(timestamp.ToString());
        listItem.SubItems.Add(message);
        statusList.Items.Insert(index, listItem);
    
        // Scroll down only if the list view is idle.
        var idleTime = TimeSpan.FromSeconds(5);
        var isListViewIdle = DateTime.Now.Subtract(this.lastScrollTime) > idleTime;
        if (isListViewIdle)
        {
           statusList.Items[statusList.Items.Count - 1].EnsureVisible();
        }
    }

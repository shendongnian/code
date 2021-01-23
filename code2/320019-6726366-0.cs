    async void DoScrape()
    {
        var feed = new Feed();
        var results = await feed.GetList();
        LstResults.BeginUpdate();  // Add this
        try
        {
            foreach (var itemObject in results)
            {
                var item = new ListViewItem(itemObject.Title);
                item.SubItems.Add(itemObject.Link);
                item.SubItems.Add(itemObject.Description);
                LstResults.Items.Add(item);
            }
        }
        finally
        {
            LstResults.EndUpdate();
        }
    }
